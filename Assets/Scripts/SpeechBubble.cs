using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    public void SetEnable(bool enable)
    {
        gameObject.SetActive(enable);
    }

    public void Hide()
    {
        SetEnable(false);
    }
}
