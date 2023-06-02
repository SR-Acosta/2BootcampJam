using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class textEspawner : MonoBehaviour
{
    public GameObject UiObject;
    public GameObject cube;
    [SerializeField]
    private GameObject canvas;
    private AutoHideMessages autoHideMessages;
    void Start()
    {
        autoHideMessages = canvas.GetComponent<AutoHideMessages>();
        UiObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //UiObject.SetActive(true);
            autoHideMessages.Show(UiObject, 6f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(UiObject);
            Destroy(cube);
        }
    }
}
