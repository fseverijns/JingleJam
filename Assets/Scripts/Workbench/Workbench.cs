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

    private bool inUse = false;
    private bool recovering = false;

    public override void Interact(Player player)
    {
        if(recovering || inUse)
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
            int randomMinigameIndex = Random.Range(0, minigames.Count - 1);
            MinigameController minigame = minigames[randomMinigameIndex];
            Instantiate(minigame, minigameContainer);
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
}
