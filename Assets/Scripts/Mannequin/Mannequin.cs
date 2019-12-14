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

    private int partsPlaced;

    public override void Interact(Player player)
    {
        Pickup pickup = player.CarryingPickup;
        if (pickup.partState != PartStateEnum.Unfixed)
        {
            SpriteRenderer partSprite;
            bool correctPart = false;

            if (pickup.partState == PartStateEnum.Broken)
            {
                brokenParts++;
            }
            if (pickup.partState == PartStateEnum.Fixed)
            {
                fixedParts++;
            }

            switch (pickup.partType)
            {
                case PartTypeEnum.head:
                    if (!headImage.activeSelf)
                    {
                        correctPart = true;
                        partSprite = headImage.GetComponent<SpriteRenderer>();
                        partSprite.sprite = pickup.GetComponentInChildren<SpriteRenderer>().sprite;
                        headImage.SetActive(true);
                    }
                    break;
                case PartTypeEnum.body:
                    if (!bodyImage.activeSelf)
                    {
                        correctPart = true;
                        partSprite = bodyImage.GetComponent<SpriteRenderer>();
                        partSprite.sprite = pickup.GetComponentInChildren<SpriteRenderer>().sprite;
                        bodyImage.SetActive(true);
                    }
                    break;
                case PartTypeEnum.legs:
                    if (!legsImage.activeSelf)
                    {
                        correctPart = true;
                        partSprite = legsImage.GetComponent<SpriteRenderer>();
                        partSprite.sprite = pickup.GetComponentInChildren<SpriteRenderer>().sprite;
                        legsImage.SetActive(true);
                    }
                    break;
                case PartTypeEnum.decoration:
                    if (!decorationImage.activeSelf)
                    {
                        correctPart = true;
                        partSprite = decorationImage.GetComponent<SpriteRenderer>();
                        partSprite.sprite = pickup.GetComponentInChildren<SpriteRenderer>().sprite;
                        decorationImage.SetActive(true);
                    }
                    break;
            }
            if (correctPart)
            {
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

    void FinishMannequin()
    {
        if (partsPlaced == 4)
        {
            headImage.SetActive(false);
            bodyImage.SetActive(false);
            legsImage.SetActive(false);
            decorationImage.SetActive(false);

            partsPlaced = 0;

            bool isSetCompleted = false;
            if (setPartsCount == 4)
            {
                isSetCompleted = true;
            }

            ScoreManager.Instance.IncreasePlayerScore(playerNumber, brokenParts, fixedParts, isSetCompleted);

            isSetCompleted = false;
            brokenParts = 0;
            fixedParts = 0;
        }
    }
}
