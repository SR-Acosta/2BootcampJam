using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMusicAMB : MonoBehaviour
{
    public AudioSource tranqui;
    public AudioSource noTranqui;
    public AudioSource battle;
    public AudioSource maxBattle;

    private GameManager _gm;
    private void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        
    }

    private void Update()
    {
        changeMusic();
    }

    private void changeMusic()
    {
        if (_gm.recollectedTreasures == 1)
        {
            tranqui.enabled = false;
            noTranqui.enabled = true;
            battle.enabled = false;
            maxBattle.enabled = false;
        }
        if (_gm.recollectedTreasures == 2)
        {tranqui.enabled = false;
            noTranqui.enabled = false;
            battle.enabled = true;
            maxBattle.enabled = false;
        }if (_gm.recollectedTreasures == 3)
        {
            tranqui.enabled = false;
            noTranqui.enabled = false;
            battle.enabled = false;
            maxBattle.enabled = true;
        }
        if (_gm.recollectedTreasures == 0)
        {
            tranqui.enabled = true;
            noTranqui.enabled = false;
            battle.enabled = false;
            maxBattle.enabled = false;
        }
    }
}
