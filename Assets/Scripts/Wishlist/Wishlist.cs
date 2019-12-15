using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wishlist : MonoBehaviour
{
    [SerializeField]
    private int playernumber;

    [SerializeField]
    private Text wisheeText;
    [SerializeField]
    private Image headSprite;
    [SerializeField]
    private Image bodySprite;
    [SerializeField]
    private Image legsSprite;
    [SerializeField]
    private Image decorationSprite;

    private PartSetEnum headPart;
    private PartSetEnum bodyPart;
    private PartSetEnum legsPart;
    private PartSetEnum decorationPart;

    [SerializeField]
    private WisheeScriptableObject wisheeOptions;
    [SerializeField]
    private WishlistSpriteOptionsScriptableObject wishlistSpriteOptions;

    // Start is called before the first frame update
    void Start()
    {
        SetWishlistParts(UnityEngine.Random.Range(1, 9));
        SetWisheeText();
    }

    public bool CompleteWishlist(PartSetEnum headSet, PartSetEnum bodySet, PartSetEnum legsSet, PartSetEnum decorationSet)
    {
        if (headPart == headSet && bodyPart == bodySet && legsPart == legsSet && decorationPart == decorationSet)
        {
            SetWishlistParts(UnityEngine.Random.Range(1, 9));
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetWisheeText()
    {
        int maxNumber = wisheeOptions.wisheeNames.Count;
        wisheeText.text = wisheeOptions.wisheeNames[UnityEngine.Random.Range(0, maxNumber)] + ", wishes:";
    }

    private void SetWishlistParts(int setNumber)
    {
        switch (setNumber)
        {
            case 1:
                headPart = PartSetEnum.Bee;
                bodyPart = PartSetEnum.Bee;
                legsPart = PartSetEnum.Bee;
                decorationPart = PartSetEnum.Bee;
                break;
            case 2:
                headPart = PartSetEnum.Dwarf;
                bodyPart = PartSetEnum.Dwarf;
                legsPart = PartSetEnum.Dwarf;
                decorationPart = PartSetEnum.Dwarf;
                break;
            case 3:
                headPart = PartSetEnum.Scientist;
                bodyPart = PartSetEnum.Scientist;
                legsPart = PartSetEnum.Scientist;
                decorationPart = PartSetEnum.Scientist;
                break;
            case 4:
                headPart = PartSetEnum.Toddy;
                bodyPart = PartSetEnum.Toddy;
                legsPart = PartSetEnum.Toddy;
                decorationPart = PartSetEnum.Toddy;
                break;
            case 5:
                headPart = GetRandomSet();
                bodyPart = GetRandomSet();
                legsPart = GetRandomSet();
                decorationPart = GetRandomSet();
                break;
            case 6:
                headPart = GetRandomSet();
                bodyPart = GetRandomSet();
                legsPart = GetRandomSet();
                decorationPart = GetRandomSet();
                break;
            case 7:
                headPart = GetRandomSet();
                bodyPart = GetRandomSet();
                legsPart = GetRandomSet();
                decorationPart = GetRandomSet();
                break;
            case 8:
                headPart = GetRandomSet();
                bodyPart = GetRandomSet();
                legsPart = GetRandomSet();
                decorationPart = GetRandomSet();
                break;
        }

        Debug.Log("Wishlist Player: " + playernumber + " " + headPart + " " + bodyPart + " " + legsPart + " " + decorationPart);
    }

    private void SetActualSprite()
    {
        foreach (WishlistObject wo in wishlistSpriteOptions.wishtlistObjectOptions)
        {
            if (wo.partSet == PartSetEnum.Bee)
            {
                if (wo.partType == PartTypeEnum.head && headPart == PartSetEnum.Bee)
                {
                    headSprite.sprite = wo.sprite;
                }
                else if (wo.partType == PartTypeEnum.body && bodyPart == PartSetEnum.Bee)
                {
                    bodySprite.sprite = wo.sprite;
                }
                else if (wo.partType == PartTypeEnum.legs && legsPart == PartSetEnum.Bee)
                {
                    legsSprite.sprite = wo.sprite;
                }
                else if (wo.partType == PartTypeEnum.decoration && decorationPart == PartSetEnum.Bee)
                {
                    decorationSprite.sprite = wo.sprite;
                }
            }
            else if (wo.partSet == PartSetEnum.Dwarf)
            {
                if (wo.partType == PartTypeEnum.head && headPart == PartSetEnum.Dwarf)
                {
                    headSprite.sprite = wo.sprite;
                }
                else if (wo.partType == PartTypeEnum.body && bodyPart == PartSetEnum.Dwarf)
                {
                    bodySprite.sprite = wo.sprite;
                }
                else if (wo.partType == PartTypeEnum.legs && legsPart == PartSetEnum.Dwarf)
                {
                    legsSprite.sprite = wo.sprite;
                }
                else if (wo.partType == PartTypeEnum.decoration && decorationPart == PartSetEnum.Dwarf)
                {
                    decorationSprite.sprite = wo.sprite;
                }
            }
            else if (wo.partSet == PartSetEnum.Scientist)
            {
                if (wo.partType == PartTypeEnum.head && headPart == PartSetEnum.Scientist)
                {
                    headSprite.sprite = wo.sprite;
                }
                else if (wo.partType == PartTypeEnum.body && bodyPart == PartSetEnum.Scientist)
                {
                    bodySprite.sprite = wo.sprite;
                }
                else if (wo.partType == PartTypeEnum.legs && legsPart == PartSetEnum.Scientist)
                {
                    legsSprite.sprite = wo.sprite;
                }
                else if (wo.partType == PartTypeEnum.decoration && decorationPart == PartSetEnum.Scientist)
                {
                    decorationSprite.sprite = wo.sprite;
                }
            }
            else if (wo.partSet == PartSetEnum.Toddy)
            {
                if (wo.partType == PartTypeEnum.head && headPart == PartSetEnum.Toddy)
                {
                    headSprite.sprite = wo.sprite;
                }
                else if (wo.partType == PartTypeEnum.body && bodyPart == PartSetEnum.Toddy)
                {
                    bodySprite.sprite = wo.sprite;
                }
                else if (wo.partType == PartTypeEnum.legs && legsPart == PartSetEnum.Toddy)
                {
                    legsSprite.sprite = wo.sprite;
                }
                else if (wo.partType == PartTypeEnum.decoration && decorationPart == PartSetEnum.Toddy)
                {
                    decorationSprite.sprite = wo.sprite;
                }
            }
        }
    }

    private PartSetEnum GetRandomSet()
    {
        int setNumber = UnityEngine.Random.Range(1, 5);
        switch (setNumber)
        {
            case 1:
                return PartSetEnum.Bee;
            case 2:
                return PartSetEnum.Dwarf;
            case 3:
                return PartSetEnum.Scientist;
            case 4:
                return PartSetEnum.Toddy;
        }
        return PartSetEnum.Toddy;
    }
}
