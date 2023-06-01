using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avisoBurroText : MonoBehaviour
{
    public GameObject UiObject;
    private GameManager _gameManager;
    void Start()
    {
        UiObject.SetActive(false);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        avisoBurro();
    }

    private void avisoBurro()
    {
        if (_gameManager.recollectedTreasures == 3)
        {
            UiObject.SetActive(true);

            disapearMessage();
            
        }
    }

    private IEnumerator disapearMessage()
    {
        yield return new WaitForSeconds(5f);
        UiObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FinishCollider")
        {
            UiObject.SetActive(false);
        }
    }
}
