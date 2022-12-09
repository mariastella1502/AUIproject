using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranusGameManager : MonoBehaviour
{
    UranusLife uranusLife;
    [SerializeField] private GameObject uranus;
    [SerializeField] private GameObject winPrefab;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject gameOverPrefab;

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        menu.SetActive(true);
        winPrefab.SetActive(false);
        gameOverPrefab.SetActive(true);
    }

    private void Awake()
    {
        uranusLife = uranus.GetComponent<UranusLife>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyAsteroids();
        DestroySpawners();
        IsGameOver();
    }

    public void DestroyAsteroids()
    {
        if ((uranusLife.currentHealth == 0) || winPrefab.activeInHierarchy == true)
        {
            var clones = GameObject.FindGameObjectsWithTag("Asteroid");
            for (int i = 0; i < clones.Length; i++)
            {
                GameObject clone = clones[i];
                //Destroy(clone);
                clone.SetActive(false);
            }
        }
    }

    public void DestroySpawners()
    {
        if ((uranusLife.currentHealth == 0) || winPrefab.activeInHierarchy == true)
        {
            var clones = GameObject.FindGameObjectsWithTag("AsteroidSpawner");
            for (int i = 0; i < clones.Length; i++)
            {
                GameObject clone = clones[i];
                clone.SetActive(false);
            }
        }
    }

    public void IsGameOver()
    {
        if (uranusLife.currentHealth == 0)
        {
            StartCoroutine(GameOver());
        }
    }

    /*
     * Manca il sistema di punti:
     * 6 Hp= 3 pianeti
     * 3 Hp= 2 pianeti
     * 1 Hp= 1 pianeta
     * Inserisci riconoscimento gesture
     * Sostituisci gesture al mouse click
     * Implementa la questione dei collezionabili
     * Implementa menu per uscire/giocare ancora, sconfitta, game over (vedi clone breakout con macchina a stati)
     * Cura grafica e animazioni
     */
}
