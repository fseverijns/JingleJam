using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mannequin : PickupInteracter
{
    [SerializeField]
    private int playerNumber;

    private PartSetEnum currentSet;
    private int setPartsCount;

    private int brokenParts;
    private int fixedParts;

    [SerializeField]
    private GameObject headImage;
    [SerializeField]
    private GameObject bodyImage;
    [SerializeField]
    private GameObject legsImage;
    [SerializeField]
    private GameObject decorationImage;

    [SerializeField]
    private AudioSource putOnMannequinSound;
    [SerializeField]
    private AudioSource mannequinCompleteSound;

    [Space]
    [SerializeField]
    private Wishlist wishlist;

    private PartSetEnum headSet;
    private PartSetEnum bodySet;
    private PartSetEnum legsSet;
    private PartSetEnum decorationSet;

    private int partsPlaced;

    public override void Interact(Player player)
    {
        if(player.playerNum != playerNumber)
        {
            return;
        }

        Pickup pickup = player.CarryingPickup;
        if (pickup.partState != PartStateEnum.Unfixed && playerNumber == player.playerNum)
        {
            SpriteRenderer partSprite;
            bool correctPart = false;

            switch (pickup.partType)
            {
                case PartTypeEnum.head:
                    if (!headImage.activeSelf)
                    {
                        correctPart = true;
                        partSprite = headImage.GetComponent<SpriteRenderer>();
                        partSprite.sprite = pickup.GetComponentInChildren<SpriteRenderer>().sprite;
                        headImage.SetActive(true);
                        headSet = pickup.partSet;

                    }
                    break;
                case PartTypeEnum.body:
                    if (!bodyImage.activeSelf)
                    {
                        correctPart = true;
                        partSprite = bodyImage.GetComponent<SpriteRenderer>();
                        partSprite.sprite = pickup.GetComponentInChildren<SpriteRenderer>().sprite;
                        bodyImage.SetActive(true);
                        bodySet = pickup.partSet;
                    }
                    break;
                case PartTypeEnum.legs:
                    if (!legsImage.activeSelf)
                    {
                        correctPart = true;
                        partSprite = legsImage.GetComponent<SpriteRenderer>();
                        partSprite.sprite = pickup.GetComponentInChildren<SpriteRenderer>().sprite;
                        legsImage.SetActive(true);
                        legsSet = pickup.partSet;
                    }
                    break;
                case PartTypeEnum.decoration:
                    if (!decorationImage.activeSelf)
                    {
                        correctPart = true;
                        partSprite = decorationImage.GetComponent<SpriteRenderer>();
                        partSprite.sprite = pickup.GetComponentInChildren<SpriteRenderer>().sprite;
                        decorationImage.SetActive(true);
                        decorationSet = pickup.partSet;
                    }
                    break;
            }
            if (correctPart)
            {
                putOnMannequinSound.Play();
                if (pickup.partState == PartStateEnum.Broken)
                {
                    brokenParts++;
                }
                if (pickup.partState == PartStateEnum.Fixed)
                {
                    fixedParts++;
                }

                if (partsPlaced == 0)
                {
                    currentSet = pickup.partSet;
                    setPartsCount++;
                }
                else if (pickup.partSet == currentSet)
                {
                    setPartsCount++;
                }

                partsPlaced++;

                player.DestroyPickup();

                FinishMannequin();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        headImage.SetActive(false);
        bodyImage.SetActive(false);
        legsImage.SetActive(false);
        decorationImage.SetActive(false);

        partsPlaced = 0;
        brokenParts = 0;
        fixedParts = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void TogglePrompt(Player player, bool state)
    {
        if (state == false)
        {
            prompt.SetActive(false);
            return;
        }

        if (player.playerNum == playerNumber && player.CarryingPickup != null)
        {
            if (player.CarryingPickup.partState != PartStateEnum.Unfixed)
            {
                if (player.CarryingPickup.partType == PartTypeEnum.head && !headImage.activeSelf)
                {
                    prompt.SetActive(true);
                    return;
                }
                else if (player.CarryingPickup.partType == PartTypeEnum.body && !bodyImage.activeSelf)
                {
                    prompt.SetActive(true);
                    return;
                }
                else if (player.CarryingPickup.partType == PartTypeEnum.legs && !legsImage.activeSelf)
                {
                    prompt.SetActive(true);
                    return;
                }
                else if (player.CarryingPickup.partType == PartTypeEnum.decoration && !decorationImage.activeSelf)
                {
                    prompt.SetActive(true);
                    return;
                }
            }
        }
        prompt.SetActive(false);
    }

    void FinishMannequin()
    {
        if (partsPlaced == 4)
        {
            headImage.SetActive(false);
            bodyImage.SetActive(false);
            legsImage.SetActive(false);
            decorationImage.SetActive(false);
            mannequinCompleteSound.Play();

            partsPlaced = 0;

            bool isSetCompleted = false;
            if (setPartsCount == 4)
            {
                isSetCompleted = true;
            }

            bool wishlistCompleted = wishlist.CompleteWishlist(headSet, bodySet, legsSet, decorationSet);

            ScoreManager.Instance.IncreasePlayerScore(playerNumber, brokenParts, fixedParts, isSetCompleted, wishlistCompleted);

            isSetCompleted = false;
            brokenParts = 0;
            fixedParts = 0;

            ScoreManager.Instance.AddFinishedToyToList(playerNumber, new FinishedToy(headImage.GetComponent<Image>(), bodyImage.GetComponent<Image>(), legsImage.GetComponent<Image>(), decorationImage.GetComponent<Image>()));
        }
    }
}
