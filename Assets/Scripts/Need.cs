using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Need : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer item = null;

    public void Setup(Item item)
    {
        this.item.sprite = item.Sprite;
    }

    public void SetEnable(bool enable)
    {
        gameObject.SetActive(enable);
        if(enable)
        {
            StartCoroutine(WaitToHide());
        }
    }

    IEnumerator WaitToHide()
    {
        yield return new WaitForSeconds(1f);
        SetEnable(false);
    }
}
