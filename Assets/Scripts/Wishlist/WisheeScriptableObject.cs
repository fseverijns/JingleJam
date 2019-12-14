using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Wishlist/WisheeScriptableObject", order = 1)]
public class WisheeScriptableObject : ScriptableObject
{
    public List<string> wisheeNames;
}
