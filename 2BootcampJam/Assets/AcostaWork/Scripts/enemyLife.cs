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
    public Animator anim;
    private void Start()
    {
        slider.maxValue = lifeCount;
        slider.value = slider.maxValue;
        slider = GetComponentInChildren<Slider>();
        slider.gameObject.SetActive(false);
        fill.color = gradient.Evaluate(1f);
        anim = GetComponent<Animator>();
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
       //anim.SetTrigger("wasHit1");
       anim.SetBool("wasHit",true);
       if (slider.value <= 1)
       {
          // anim.ResetTrigger("wasHit1");
          anim.SetBool("wasHit", false);

       }
       if (slider.value <= 0)
       {
           Die();   
       }
   }
   private void Die()
   {
       Destroy(gameObject);  
   }
}