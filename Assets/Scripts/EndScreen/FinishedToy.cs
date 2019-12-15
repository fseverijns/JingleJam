using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishedToy : MonoBehaviour
{
    [SerializeField]
    private Image headImage;
    [SerializeField]
    private Image bodyImage;
    [SerializeField]
    private Image legsImage;
    [SerializeField]
    private Image decorationImage;

    public FinishedToy (Image head, Image body, Image legs, Image decoration)
    {
        this.headImage = head;
        this.bodyImage = body;
        this.legsImage = legs;
        this.decorationImage = decoration;
    }

    public void SetToyImages(Image head, Image body, Image legs, Image decoration)
    {
        this.headImage = head;
        this.bodyImage = body;
        this.legsImage = legs;
        this.decorationImage = decoration;
    }

    public FinishedToy CreateFinishedToy(Image head, Image body, Image legs, Image decoration)
    {
        return new FinishedToy(head, body, legs, decoration);
    }
}
