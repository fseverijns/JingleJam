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

    public bool inUse = false;
    public bool recovering = false;

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
            instantiatedMinigame.StartMinigame(player, this);
        }
    }

    public void FinishMiniGame(Player player, bool success)
    {
        player.CarryingPickup.snapToPlayer = true;
        player.UnFreezePlayer();
        if(!success)
        {
            player.CarryingPickup.partState = PartStateEnum.Broken;
            recovering = true;
            Invoke("ReactivateWorkbench", reactivationTime);
        }
        else
        {
            player.CarryingPickup.partState = PartStateEnum.Fixed;
        }

        inUse = false;
    }

    private void ReactivateWorkbench()
    {
        recovering = false;
        //todo change graphics
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
