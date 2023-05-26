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
    //enemy life
    
    
    private void Start()
    {
        slider.maxValue = lifeCount;
        slider.value = slider.maxValue;
        slider = GetComponentInChildren<Slider>();
        slider.gameObject.SetActive(false);
        fill.color = gradient.Evaluate(1f);
    }
    private void Update()
    {
        if (slider.value < slider.maxValue)
        {
            slider.gameObject.SetActive(true);
        }
        fill.color = gradient.Evaluate(slider.normalizedValue);
        //dead();
    }

   /* private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            slider.value -= 20;
        }
    }
    
    private void dead()
    {
        if (slider.value == 0)
        {
            Destroy(gameObject);
        }
    }*/
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
       Destroy(gameObject);  
   }
}