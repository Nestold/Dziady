using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerSerializeFields))]
public class Player : MonoBehaviour
{
    public Vector3 Position => transform.position;
    public Item PickupedItem => pickupedItem;

    [SerializeField]
    private float movementSpeed = 5f;

    private PlayerSerializeFields serializeFields => GetComponent<PlayerSerializeFields>();
    private Vector2 movement;
    private Item pickupedItem;
    private bool canMove = true;

    public void PickupItem(Item item)
    {
        serializeFields.PickupedItemSprite.sprite = item.Sprite;
        pickupedItem = item;
    }

    public void UnpickItem()
    {
        serializeFields.PickupedItemSprite.sprite = null;
        pickupedItem = null;
    }

    public void Hurt()
    {
        Debug.Log("Player Hurt");
        StartCoroutine(WaitForCanMove());
        Vector2 randMove = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
        serializeFields.Rb.AddForce(randMove * 5f, ForceMode2D.Impulse);
    }

    private bool mouseOnRightSide => Input.mousePosition.x > Screen.width / 2f;

    private void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (mouseOnRightSide)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Hurt();
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
            serializeFields.Rb.MovePosition(serializeFields.Rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    IEnumerator WaitForCanMove()
    {
        canMove = false;
        foreach(var s in serializeFields.Model)
        {
            s.color = new Color(1f, 0f, 0f, 1f);
        }
        yield return new WaitForSeconds(.05f);
        canMove = true;
        foreach (var s in serializeFields.Model)
        {
            s.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
