using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishedToy : MonoBehaviour
{
    [SerializeField]
    public Image headImage;
    [SerializeField]
    public Image bodyImage;
    [SerializeField]
    public Image legsImage;
    [SerializeField]
    public Image decorationImage;

    public void SetToyImages(Sprite head, Sprite body, Sprite legs, Sprite decoration)
    {
        this.headImage.sprite = head;
        this.bodyImage.sprite = body;
        this.legsImage.sprite = legs;
        this.decorationImage.sprite = decoration;
    }

}
