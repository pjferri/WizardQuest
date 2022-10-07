using System;
using System.Collections;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [Header("Spell Settings")]
    public GameObject projectile;
    public float projectileSpeed;
    public float projectileRange;
    public float startTimeBetweenShots;
    public float timeBetweenShots;

    [Header("Potion Settings")]
    public int potionCount;
    public GameObject potionPrefab;
    public GameObject potionSpawn;
    public float potionSpeed;
    public float potionRange;
    public GameObject potionEffects;
    public GameObject potionInHand;

    // Use this for initialization

    void Start()
    {
        timeBetweenShots = 0;
    }

    // Update is called once per frame

    void Update()
    {
        //Prevents auto fire
        if (Input.GetMouseButtonDown(0) && timeBetweenShots <= 0)
        {
            timeBetweenShots = startTimeBetweenShots;
            timeBetweenShots -= Time.deltaTime;
            CastSpell();
        }
        if (timeBetweenShots > 0)
        {
            timeBetweenShots -= Time.deltaTime;
        }

        //if right mouse button down and if number of potions is hirer than 0
        //FirePotion()
        if (Input.GetMouseButtonDown(1) && potionCount > 0)
        {
            ThrowPotion();
            potionCount--;
        }
        else {
            potionInHand.SetActive(false);
        }

        if (potionCount > 0) {
            potionInHand.SetActive(true);
        }

    }

    private void ThrowPotion()
    {
        GameObject potionClone = Instantiate(potionPrefab, potionSpawn.transform.position, transform.rotation);
        Rigidbody2D potionRB = potionClone.GetComponent<Rigidbody2D>();
        potionClone.GetComponent<Rigidbody2D>().velocity = transform.up * potionSpeed;


        StartCoroutine(SpawnPotionParticlesAndDestroy(potionClone));

    }

    IEnumerator SpawnPotionParticlesAndDestroy(GameObject potionClone)
    {
        yield return new WaitForSeconds(potionRange);
        GameObject potionParticleClone = Instantiate(potionEffects, potionClone.transform.position, transform.rotation);
        GameObject.Destroy(potionClone);
    }

    void CastSpell()
    {
        //Fire the selected projectile
        GameObject projectile_instance = Instantiate(projectile, transform.position, transform.rotation);
        //Add velocity to the projectile
        Rigidbody2D rb = projectile_instance.GetComponent<Rigidbody2D>();


        projectile_instance.GetComponent<Rigidbody2D>().velocity = transform.up * projectileSpeed;
        GameObject.Destroy(projectile_instance, projectileRange);

    }
}