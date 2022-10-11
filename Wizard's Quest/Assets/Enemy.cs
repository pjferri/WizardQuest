using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    private SpriteRenderer spriteRenderer;
    public Color damageColor;
    public float damageTime;
    public float damageToDeal;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(ShowDamage());
        if (health <= 0) {
            Destroy(this.gameObject);
        }
    }

    IEnumerator ShowDamage()
    {
        spriteRenderer.color = damageColor;

        yield return new WaitForSeconds(damageTime);

        spriteRenderer.color = Color.white;
    }
}
