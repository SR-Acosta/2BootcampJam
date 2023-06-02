using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class mulaLife : MonoBehaviour
{
    public Slider slider;
    public float lifeCount;
    public Gradient gradient;
    public Image fill;
    private CineMachiner cineMachiner;
    [SerializeField]
    private GameObject cameraManager;
    private void Start()
    {
        slider.maxValue = lifeCount;
        slider.value = slider.maxValue;
        slider = GetComponentInChildren<Slider>();
        slider.gameObject.SetActive(false);
        fill.color = gradient.Evaluate(1f);
        cineMachiner = cameraManager.GetComponent<CineMachiner>();
    }
    private void Update()
    {        
        if (slider.value < slider.maxValue)
        {
            slider.gameObject.SetActive(true);
        }
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void TakeDamageMula(float damage)
    {
        AnimationsAndEffects();
        slider.value -= damage;
        if (slider.value <= 0)
        {
            Die();   
        }
    }
    private void Die()
    {
        Destroy(gameObject, 2f);
        SceneManager.LoadScene(1);
    }

    private void AnimationsAndEffects()
    {
        StartCoroutine(cineMachiner.ShakeCamera(0.3f));
    }
}
