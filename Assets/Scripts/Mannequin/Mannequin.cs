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
        if (pickup.partState == PartStateEnum.Unfixed)
        {
            SpriteRenderer partSprite;

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
                    partSprite = headImage.GetComponent<SpriteRenderer>();
                    partSprite.sprite = pickup.GetComponent<SpriteRenderer>().sprite;
                    headImage.SetActive(true);
                    break;
                case PartTypeEnum.body:
                    partSprite = bodyImage.GetComponent<SpriteRenderer>();
                    partSprite.sprite = pickup.GetComponent<SpriteRenderer>().sprite;
                    bodyImage.SetActive(true);
                    break;
                case PartTypeEnum.legs:
                    partSprite = legsImage.GetComponent<SpriteRenderer>();
                    partSprite.sprite = pickup.GetComponent<SpriteRenderer>().sprite;
                    legsImage.SetActive(true);
                    break;
                case PartTypeEnum.decoration:
                    partSprite = decorationImage.GetComponent<SpriteRenderer>();
                    partSprite.sprite = pickup.GetComponent<SpriteRenderer>().sprite;
                    decorationImage.SetActive(true);
                    break;
            }
            partsPlaced++;

            FinishMannequin();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        headImage.GetComponent<GameObject>().SetActive(false);
        bodyImage.GetComponent<GameObject>().SetActive(false);
        legsImage.GetComponent<GameObject>().SetActive(false);
        decorationImage.GetComponent<GameObject>().SetActive(false);

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

            bool setCompleted = false;

            GameManager.Instance.IncreasePlayerScore(playerNumber, brokenParts, fixedParts, setCompleted);

            brokenParts = 0;
            fixedParts = 0;
        }
    }
}
