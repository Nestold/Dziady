using System.Collections.Generic;
using UnityEngine;

public class Spirit : UsableObject
{
    [SerializeField]
    private ESpiritType spiritType = ESpiritType.None;

    [SerializeField]
    private SpeechBubble speechBubble = null;

    [SerializeField]
    private Need need = null;

    [SerializeField]
    private new SpiritParticleSystem particleSystem = null;

    private Item selectedItem;
    private int clickState = 0;

    private void Start()
    {
        Setup();
        Instantiate(particleSystem, transform.position, Quaternion.identity);
    }

    public void Setup()
    {
        selectedItem = GameManager.Instance.GetRandomItem();
        need.Setup(selectedItem);
    }

    public void SendBack()
    {
        Instantiate(particleSystem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public override void Use()
    {
        if(GameManager.Instance.Player.PickupedItem == null)
        {
            speechBubble.SetEnable(true);
            need.SetEnable(true);
            clickState++;
            if(clickState == 3)
            {
                GameManager.Instance.Player.Hurt();
                SendBack();
            }
        }
        else
        {
            if(!selectedItem.ItemName.Equals(GameManager.Instance.Player.PickupedItem.ItemName))
            {
                GameManager.Instance.Player.Hurt();
            }
            SendBack();
            GameManager.Instance.Player.UnpickItem();
        }
    }
}

public enum ESpiritState
{
    None = 0,
    Calm = 1,
    Nervous = 2,
    Mad = 3,
    Furious = 4
}