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
    private SpriteRenderer headSprite;
    [SerializeField]
    private SpriteRenderer bodySprite;
    [SerializeField]
    private SpriteRenderer legsSprite;
    [SerializeField]
    private SpriteRenderer decorationSprite;

    private PartSetEnum headPart;
    private PartSetEnum bodyPart;
    private PartSetEnum legsPart;
    private PartSetEnum decorationPart;

    [SerializeField]
    private WisheeScriptableObject wisheeOptions;

    // Start is called before the first frame update
    void Start()
    {
        SetWishlistParts(UnityEngine.Random.Range(1, 9));
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
