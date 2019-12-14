using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Wishlist/WishlistSpriteOptionsScriptableObject", order = 1)]
public class WishlistSpriteOptionsScriptableObject : ScriptableObject
{
    public List<WishlistObject> wishtlistObjectOptions = new List<WishlistObject>();
}

[System.Serializable]
public class WishlistObject
{
    public Sprite sprite;
    public PartSetEnum partSet;
    public PartTypeEnum partType;
}