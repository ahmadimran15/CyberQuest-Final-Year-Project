using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    //public CutScene2Loading sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = GameManager.Instance.currentHealth;
        //healthBar.SetMaxHealth(GameManager.Instance.maxHealth);
        healthBar.SetHealth(currentHealth);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        GameManager.Instance.currentHealth = currentHealth;
        healthBar.SetHealth(currentHealth);
    }
}