using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSerializeFields : MonoBehaviour
{
    public Rigidbody2D Rb => rb;
    public SpriteRenderer PickupedItemSprite => pickupedItemSprite;
    public List<SpriteRenderer> Model => model;

    [SerializeField]
    private Rigidbody2D rb = null;
    [SerializeField]
    private SpriteRenderer pickupedItemSprite = null;
    [SerializeField]
    private List<SpriteRenderer> model = null;
}
