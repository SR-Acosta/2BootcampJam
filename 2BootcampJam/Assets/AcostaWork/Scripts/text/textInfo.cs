using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class textInfo : MonoBehaviour
{
    public GameObject UiObject;
    public GameObject cube;
    void Start()
    {
        UiObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(UiObject);
            Destroy(cube);
        }
    }
}
