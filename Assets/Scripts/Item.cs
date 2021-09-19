using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : UsableObject
{
    public Sprite Sprite => spriteRenderer.sprite;

    public string ItemName => itemName;

    [SerializeField]
    private SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private string itemName = "NoNe";

    public override void Use()
    {
        GameManager.Instance.Player.PickupItem(this);
    }
}
