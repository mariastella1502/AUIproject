using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranusLife : MonoBehaviour
{   

    public int currentHealth = 6;
    [SerializeField] private int maxHealth = 6;
    [SerializeField] private GameObject explosionPrefab;

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        }
    }

    void Die()
    {
        //gameObject.GetComponent<MeshRenderer>().enabled = false; //per renderlo invisibile, accedi alle due compononeti del prefab (169 e 180) e fai la stessa cosa
        gameObject.SetActive(false);
        SoundManagerScript.PlaySound("UranusExplosion");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            currentHealth--;
            SoundManagerScript.PlaySound("impact");
        }
    }

}
