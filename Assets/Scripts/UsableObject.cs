using UnityEngine;
using UnityEngine.EventSystems;

public class UsableObject : MonoBehaviour
{
    [SerializeField]
    private GameObject highlight = null;

    [SerializeField]
    private float rangeToUse = 3f;

    private bool inRange
    {
        get
        {
            return (GameManager.Instance.Player.Position - transform.position).magnitude < rangeToUse;
        }
    }

    private bool mouseOver = false;

    public virtual void Use()
    {

    }

    public void Highlight(bool highlight)
    {
        this.highlight.SetActive(highlight);
    }

    private void OnMouseEnter()
    {
        mouseOver = true;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
        Highlight(false);
    }

    private void OnMouseOver()
    {
        if(inRange)
        {
            Highlight(mouseOver);
        }
        else
        {
            Highlight(false);
        }
    }

    private void OnMouseUpAsButton()
    {
        if(inRange)
        {
            Use();
        }
    }
}
