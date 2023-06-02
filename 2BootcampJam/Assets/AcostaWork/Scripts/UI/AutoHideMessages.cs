using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AutoHideMessages : MonoBehaviour
{
    public IEnumerator AutoHide(GameObject messageContainer, float delay)
    {
        yield return new WaitForSeconds(delay); 
        messageContainer.SetActive(false);
    }

    public void Show(GameObject messageContainer, float delay)
    {
        messageContainer.SetActive(true);
        StartCoroutine(AutoHide(messageContainer, delay));
    }
}
