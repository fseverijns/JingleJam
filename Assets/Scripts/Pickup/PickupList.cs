using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Pickups/PickupsList", order = 1)]
public class PickupList : ScriptableObject
{
    public List<PickupForList> pickups;

    public Sprite GetBrokenVersion(Pickup pickup)
    {
        foreach (PickupForList p in pickups)
        {
            if (pickup.partSet == p.partSet && pickup.partType == p.partType && p.partState == PartStateEnum.Broken)
            {
                return p.sprite;
            }
        }
        return null;
    }

    public Sprite GetFixedVersion(Pickup pickup)
    {
        foreach (PickupForList p in pickups)
        {
            if (pickup.partSet == p.partSet && pickup.partType == pickup.partType && p.partState == PartStateEnum.Fixed)
            {
                return p.sprite;
            }
        }
        return null;
    }
}

[System.Serializable]
public class PickupForList
{
    public Sprite sprite;
    public PartSetEnum partSet;
    public PartTypeEnum partType;
    public PartStateEnum partState;
}
