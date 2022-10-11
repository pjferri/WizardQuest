using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //Set health here
    public float maxHealth = 100;
    public float currentHealth;

    //Set invulnerability here
    private float invulnPeriod = 0;
    private SpriteRenderer renderer;
    public Color damageColor;
    public float startInvulnPeriod;

    //Called when the script instance is being loaded
    void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    //Update is called every frame, if the MonoBehaviour is enabled
    void Update()
    {
        if (invulnPeriod > 0)
        {
                renderer.material.color = damageColor;
        }
        else
        {
                renderer.material.color = Color.white;
        }

            invulnPeriod -= Time.deltaTime;
    }

    //Inflicts damage and triggers the invulnerability period
    public void Damage(float damageAmount)
    {
        if (damageAmount > 0) {
            if (invulnPeriod <= 0) {
                currentHealth -= damageAmount;

                if (currentHealth <= 0) {
                    currentHealth = 0;
                    Debug.Log("You have died!");
                }
                invulnPeriod = startInvulnPeriod;
            }
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Enemy enemyScript = collider.GetComponent<Enemy>();
            Damage(enemyScript.damageToDeal);
        }
    }
}