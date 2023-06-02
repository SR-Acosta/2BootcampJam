using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avisoBurroText : MonoBehaviour
{
    public GameObject UiObject;
    [SerializeField]
    private GameObject canvas;
    private bool hasReached3;
    private AutoHideMessages autoHideMessages;
    private GameManager _gameManager;
    void Start()
    {
        autoHideMessages = canvas.GetComponent<AutoHideMessages>();
        hasReached3 = false;
        UiObject.SetActive(false);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        showTreasureDialog();
    }

    private void showTreasureDialog()
    {
        if (_gameManager.recollectedTreasures == 3 && !hasReached3)
        {
            autoHideMessages.Show(UiObject, 6f);
            hasReached3 = true;
        }

        if (_gameManager.recollectedTreasures == 0)
        {
            hasReached3 = false;
        }
    }
}
