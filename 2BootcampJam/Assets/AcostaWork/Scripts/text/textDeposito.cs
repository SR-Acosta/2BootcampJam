using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class textDeposito : MonoBehaviour
{
    public GameObject UiObject;
    public GameObject cube;
    private GameManager _gameManager;
    void Start()
    {
        UiObject.SetActive(false);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (_gameManager.recollectedTreasures == 3)
            {
                UiObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UiObject.SetActive(false);
        }
    }
}
