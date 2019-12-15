using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : PickupInteracter
{
    [SerializeField]
    private List<MinigameController> minigames = new List<MinigameController>();
    [SerializeField]
    private Transform minigameContainer;
    [SerializeField]
    private Transform pickupPosition;
    [SerializeField]
    private Transform playerPosition;
    [SerializeField]
    private float reactivationTime;

    [SerializeField]
    private AudioSource putItemInWorkbenchSound;
    [SerializeField]
    private AudioSource workbenchSuccessSound;
    [SerializeField]
    private AudioSource workbenchFailSound1;
    [SerializeField]
    private AudioSource workbenchFailSound2;
    [SerializeField]
    private AudioSource workbenchFailSound3;
    [SerializeField]
    private AudioSource workbenchWorkingSound;

    [SerializeField]
    private GameObject sparksParticles;
    [SerializeField]
    private GameObject smokeParticles;
    [SerializeField]
    private GameObject dustParticles;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite workbenchNormalSprite;
    [SerializeField]
    private Sprite workbenchBrokenSprite;

    [SerializeField]
    private PickupList pickupList;

    private bool inUse = false;
    private bool recovering = false;

    public override void Interact(Player player)
    {
        if(recovering || inUse)
        {
            return;
        }

        if(player.CarryingPickup.partState != PartStateEnum.Unfixed)
        {
            return;
        }

        putItemInWorkbenchSound.Play();
        workbenchWorkingSound.Play();

        player.FreezePlayer();
        player.transform.position = playerPosition.position;
        player.CarryingPickup.snapToPlayer = false;
        player.CarryingPickup.transform.position = pickupPosition.position;

        inUse = true;


        SpawnMinigame(player);
    }

    private void SpawnMinigame(Player player)
    {
        if (minigames.Count > 0)
        {
            int randomMinigameIndex = Random.Range(0, minigames.Count);
            MinigameController minigame = minigames[randomMinigameIndex];
            MinigameController instantiatedMinigame = Instantiate(minigame, minigameContainer);
            Debug.Log(minigameContainer, minigameContainer.gameObject);
            instantiatedMinigame.StartMinigame(player, this);
            dustParticles.SetActive(true);
        }
    }

    public void FinishMiniGame(Player player, bool success)
    {
        dustParticles.SetActive(false);
        workbenchWorkingSound.Stop();
        player.CarryingPickup.snapToPlayer = true;
        player.UnFreezePlayer();
        if(!success)
        {
            PlayRandomFailSound();
            player.CarryingPickup.partState = PartStateEnum.Broken;
            player.CarryingPickup.spriteRenderer.sprite = pickupList.GetBrokenVersion(player.CarryingPickup);
            recovering = true;
            spriteRenderer.sprite = workbenchBrokenSprite;
            sparksParticles.SetActive(true);
            smokeParticles.SetActive(true);
            Invoke("ReactivateWorkbench", reactivationTime);
        }
        else
        {
            workbenchSuccessSound.Play();
            player.CarryingPickup.partState = PartStateEnum.Fixed;
            player.CarryingPickup.spriteRenderer.sprite = pickupList.GetFixedVersion(player.CarryingPickup);  
        }

        inUse = false;
    }

    private void PlayRandomFailSound()
    {
        int chance = Random.Range(0, 11);
        if (chance <= 6)
        {
            workbenchFailSound1.Play();
        }
        else if (chance >= 7 && chance <= 9)
        {
            workbenchFailSound2.Play();
        }
        else
        {
            workbenchFailSound3.Play();
        }
    }

    private void ReactivateWorkbench()
    {
        recovering = false;
        spriteRenderer.sprite = workbenchNormalSprite;
        sparksParticles.SetActive(false);
        smokeParticles.SetActive(false);
    }

    public override void TogglePrompt(Player player, bool state)
    {
        if(state == false)
        {
            prompt.SetActive(false);
            return;
        }

        if (!inUse && !recovering && player.CarryingPickup != null)
        {
            if (player.CarryingPickup.partState == PartStateEnum.Unfixed)
            {
                prompt.SetActive(true);
                return;
            }
        }
        prompt.SetActive(false);
    }
}
