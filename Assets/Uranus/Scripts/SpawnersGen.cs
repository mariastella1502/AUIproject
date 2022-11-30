using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersGen : MonoBehaviour
{
    private Vector3 center;
    [SerializeField] private Vector3 size;
    [SerializeField] private GameObject spawnerPrefab;
    [SerializeField] private int timeSpawn = 15;
    [SerializeField] private int spawnersNumber = 1;
    [SerializeField] private bool showSpawnArea = true;

    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;
        //Start the coroutine we define below named TimeSpawnDefiner.
        StartCoroutine(TimeSpawnDefiner());
        SpawnSpawner();
        SpawnSpawner();

    }

    IEnumerator TimeSpawnDefiner()
    {
        while (true)
        {
            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(timeSpawn);

            _SpawnSpawners();
            spawnersNumber++; //più che aumentare il numero di asteroidi forse ha senso abilitare più spawner
            //per farlo fai letteralmente uno spawner di spawner
        }
    }

    public void _SpawnSpawners()
    {
        for (int i = 0; i < spawnersNumber - 1; i++)
        {
            SpawnSpawner();
        }
    }

    public void SpawnSpawner()
    {
        Vector3 pos = center + new Vector3(Random.Range((-size.x / 2) - 0.1f, (size.x / 2) - 0.1f), Random.Range((-size.y / 2) - 0.1f, (size.y / 2) - 0.1f), Random.Range((-size.z / 2) - 0.1f, (size.z / 2) - 0.1f));

        Instantiate(spawnerPrefab, pos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        if (!showSpawnArea)
            return;

        Gizmos.color = new Color(0, 0, 128, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
