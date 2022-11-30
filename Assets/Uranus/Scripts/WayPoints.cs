using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    /*
    public GameObject[] waypoints;
    public EllipseGenerator ellipseGen;
    private int current = 0;
    private float rotSpeed;
    [SerializeField] private float speed;
    private float WPradius = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(ellipseGen._ellipsePoints[current], transform.position)<WPradius)
        {
            current++;
            if(current >= ellipseGen._ellipsePoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, ellipseGen._ellipsePoints[current], Time.deltaTime * speed);
    }
    */

    private Vector3[] wayPoints = new Vector3[4];
    private int current = 0;
    private float rotSpeed;
    [SerializeField] private float speed;
    private float WPradius = 0.1f;

    private void Start()
    {
        wayPoints[0] = new Vector3(5, 0, 10); //attenzione a settare i way points perché se si sovrappongono ad Urano da la null reference exception all'impatto
        wayPoints[1] = new Vector3(2, 0, 13);
        wayPoints[2] = new Vector3(-2, 0, 10);
        wayPoints[3] = new Vector3(-5, 0, 7);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(wayPoints[current], transform.position) < WPradius)
        {
            current++;
            if (current >= wayPoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[current], Time.deltaTime * speed);
    }
}
