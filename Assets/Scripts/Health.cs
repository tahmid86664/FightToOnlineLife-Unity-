using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public enum objectList { Player, FinalExam};
    public objectList chooseObject = objectList.Player; 
    public float health = 0f;

    private float currentHealth = 0f;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        ChooseObject();

        SetHealth();
    }

    public void SetHealth()
    {
        healthBar.SetMaxHealth(health);
        currentHealth = health;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if(chooseObject == objectList.Player)
        {
            //Debug.Log("Die");
            GameManager.gm.LoadGameOverScene();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void ChooseObject()
    {
        switch (chooseObject)
        {
            case objectList.Player:
                chooseObject = objectList.Player;
                break;
            case objectList.FinalExam:
                chooseObject = objectList.FinalExam;
                break;
        }
    }
}
