using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
   public int recollectedTreasures;
   public int totalTreasures;
   public TMP_Text totalScore;
   private void Start()
   {
        recollectedTreasures = 0;
        totalTreasures = 0;
        if (PlayerPrefs.GetInt("finalScore") != 0)
        {
            totalTreasures = PlayerPrefs.GetInt("finalScore");
        }
      
      totalScore.text = totalTreasures.ToString();
   }

   private void Update()
   {
      totalScore.text = totalTreasures.ToString();
      PlayerPrefs.SetInt("finalScore", totalTreasures);
   }
}
