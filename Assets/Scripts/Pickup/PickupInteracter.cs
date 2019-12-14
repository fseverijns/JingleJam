using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupInteracter : MonoBehaviour
{
    [SerializeField]
    protected GameObject prompt;

    public abstract void Interact(Player player);

    public abstract void TogglePrompt(Player player, bool state);
}
