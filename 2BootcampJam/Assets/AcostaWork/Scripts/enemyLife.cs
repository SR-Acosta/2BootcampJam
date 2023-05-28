using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
public class enemyLife : MonoBehaviour
{
    public Slider slider;
    public float lifeCount;
    public Gradient gradient;
    public Image fill;
    private Animator anim;
    private waveManager _waveManager;
    private void Start()
    {
        slider.maxValue = lifeCount;
        slider.value = slider.maxValue;
        slider = GetComponentInChildren<Slider>();
        slider.gameObject.SetActive(false);
        fill.color = gradient.Evaluate(1f);
        anim = GetComponent<Animator>();
        _waveManager = GameObject.Find("GameManager").GetComponent<waveManager>();
    }
    private void Update()
    {        
        if (slider.value < slider.maxValue)
        {
            slider.gameObject.SetActive(true);
        }
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void TakeDamage(float damage)
   {
       slider.value -= damage;
       if (slider.value <= 0)
       {
           Die();   
       }
   }
   private void Die()
   {
       anim.SetBool("isDeath",true);
       _waveManager.enemiesSpawned -= 1;
       Destroy(gameObject, 10f);
   }
}