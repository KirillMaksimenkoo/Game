using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float maxHealth = 100f;
    public float HP;
    public float decreaseRate = 10f;

    public Image healthBarImage;

    private bool shouldDecrease = false;

    public Finish finish;

    void Start()
    {
        HP = maxHealth;
    }

    void Update()
    {
        if (shouldDecrease)
        {
            float decrease = (Time.deltaTime * decreaseRate) / maxHealth;
            HP -= decrease * 100;

            if (healthBarImage.fillAmount - decrease >= 0)
            {
                healthBarImage.fillAmount -= decrease;
            }
            else
            {
                finish.LoseGame();
                healthBarImage.fillAmount = 0f;
                Time.timeScale = 0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fuel"))
        {
            TakeHeal(30f);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("MehanicObj"))
        {
            shouldDecrease = true;
            Destroy(other.gameObject);
        }
    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RedFish"))
        {
            TakeDamage(15f);
        }
        
        if (collision.gameObject.CompareTag("BlueFish"))
        {
            TakeDamage(25f);
        }
        
        if (collision.gameObject.CompareTag("OrangeFish"))
        {
            TakeDamage(10f);
        }
        
        if (collision.gameObject.CompareTag("BOOM"))
        {
            TakeDamage(30f);
        }
    }

    void TakeDamage(float damage)
    {
        HP -= damage;
        healthBarImage.fillAmount = HP / maxHealth;

        if (HP <= 0)
        {
            healthBarImage.fillAmount = 0f;
            Time.timeScale = 0f;
        }
    }

    void TakeHeal(float heal)
    {
        HP += heal;
        if (HP > maxHealth)
        {
            HP = maxHealth;
        }
        healthBarImage.fillAmount = HP / maxHealth;
    }
}