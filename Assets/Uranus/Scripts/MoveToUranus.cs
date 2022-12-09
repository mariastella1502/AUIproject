using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToUranus : MonoBehaviour
{
    private Vector3 urPos;
    public float speed =5;
    public float rotSpeed = 5;
    UranusLife uranusLife;

    private void Start()
    {
        if (GameObject.Find("Uranus") != null)
        {
            urPos = GameObject.Find("Uranus").transform.position;
            uranusLife = GameObject.Find("Uranus").GetComponent<UranusLife>();
        }

    }

    void Update()
    {
        if (GameObject.Find("Uranus") != null && uranusLife.isPause == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, urPos, Time.deltaTime * speed);
            transform.RotateAround(transform.position, transform.up, rotSpeed * Time.deltaTime);
        }
        
    }

}
