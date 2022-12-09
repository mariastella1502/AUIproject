using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranusGameManager : MonoBehaviour
{
    UranusLife uranusLife;
    SpawnAsteroids spawnAsteroids;
    SpawnAsteroids spawnAsteroids2;
    SpawnAsteroids spawnAsteroids3;
    SpawnAsteroids spawnFake;
    SpawnAsteroids spawnFake2;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject spawner2;
    [SerializeField] private GameObject spawner3;
    [SerializeField] private GameObject FakeSpawner;
    [SerializeField] private GameObject FakeSpawner2;
    [SerializeField] private GameObject uranus;
    [SerializeField] private GameObject winPrefab;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject gameOverPrefab;
    [SerializeField] private GameObject pausePrefab;
    [SerializeField] private GameObject pauseButton;
    public bool PauseFinish = false;

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        menu.SetActive(true);
        winPrefab.SetActive(false);
        gameOverPrefab.SetActive(true);
        pauseButton.SetActive(false);
    }

    private void Awake()
    {
        uranusLife = uranus.GetComponent<UranusLife>();
        spawnAsteroids = spawner.GetComponent<SpawnAsteroids>();
        spawnAsteroids2 = spawner2.GetComponent<SpawnAsteroids>();
        spawnAsteroids3 = spawner3.GetComponent<SpawnAsteroids>();
        spawnFake = FakeSpawner.GetComponent<SpawnAsteroids>();
        spawnFake2 = FakeSpawner2.GetComponent<SpawnAsteroids>();
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
        //IsPause();
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
    
    public void IsPause(bool PauseFinish)
    {
        if (pausePrefab.activeInHierarchy == true)
        {
            PauseFinish = false;
            pauseButton.SetActive(false);
            spawner.SetActive(false);
            spawner2.SetActive(false);
            spawner3.SetActive(false);
            FakeSpawner.SetActive(false);
            FakeSpawner2.SetActive(false);

        }

        if (PauseFinish == true)
        {
            spawner.SetActive(true);
            spawner2.SetActive(true);
            spawner3.SetActive(true);
            spawnAsteroids.SpawnAgain();
            spawnAsteroids2.SpawnAgain();
            spawnAsteroids3.SpawnAgain();
            FakeSpawner.SetActive(true);
            FakeSpawner2.SetActive(true);
            spawnFake.SpawnAgain();
            spawnFake2.SpawnAgain();
            pauseButton.SetActive(true);
        }
    }
    
    /*
    public void IsPause()
    {
        var spawners = GameObject.FindGameObjectsWithTag("AsteroidSpawner");
        var asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        if (pausePrefab.activeInHierarchy == true)
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                GameObject spawner = spawners[i];
                spawner.SetActive(false);
            }

            for (int i = 0; i < asteroids.Length; i++)
            {
                GameObject asteroid = asteroids[i];
                asteroid.SetActive(false);
            }

        }
        else
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                GameObject spawner = spawners[i];
                spawner.SetActive(true);
            }

            for (int i = 0; i < asteroids.Length; i++)
            {
                GameObject asteroid = asteroids[i];
                asteroid.SetActive(true);
            }
        }
    }
    */

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
