using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToFake : MonoBehaviour
{
    private Vector3 urPos;
    public float speed = 5;
    public float rotSpeed = 5;

    private void Start()
    {
        if (GameObject.Find("NoiseTarget") != null)
        {
            urPos = GameObject.Find("NoiseTarget").transform.position;
        }
    }

    void Update()
    {
        if (GameObject.Find("NoiseTarget") != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, urPos, Time.deltaTime * speed);
            transform.RotateAround(transform.position, transform.up, rotSpeed * Time.deltaTime);
        }
    }


}
