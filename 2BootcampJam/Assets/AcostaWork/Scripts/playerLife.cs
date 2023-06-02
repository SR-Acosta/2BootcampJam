using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playerLife : MonoBehaviour
{
    public Slider slider;
    public float lifeCount;
    public Gradient gradient;
    public Image fill;
    private Animator anim;
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
        anim = GetComponent<Animator>();
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
    public void TakeDamagePlayer(float damage)
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
        anim.SetTrigger("Hurt");
        StartCoroutine(cineMachiner.ShakeCamera(0.3f));
    }
}
