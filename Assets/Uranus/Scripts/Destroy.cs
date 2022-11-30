using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private Vector3 colPos;
    private Vector3 touchPos;
    [SerializeField] private GameObject explosionPrefab;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //per far apparire raggio vedi come funziona ray e raycast, sennò fai apparire un cilindro che fa la stessa roba
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform.gameObject != null && hit.transform.gameObject.CompareTag("Asteroid"))
            {
                touchPos = hit.transform.position;
                GameObject.Destroy(hit.transform.gameObject);
                //Instantiate(explosionPrefab, touchPos, Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Uranus"))
        {
            Destroy(gameObject);
            colPos = gameObject.transform.position;
            Instantiate(explosionPrefab, colPos, Quaternion.identity);

        }

        if (other.gameObject.CompareTag("NoiseTarget"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("laser"))
        {
            Destroy(gameObject);
        }

                /*
        if (other.gameObject.CompareTag("NoiseTarget"))
        {
            Destroy(gameObject);
        }
        */
    }

}
