using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;


public class CanvaCameraLoader : MonoBehaviour
{
    Canvas canvas;


    // Start is called before the first frame update
    void Start()
    {
        canvas = gameObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = Camera.main;
        canvas.planeDistance = 1;
        gameObject.AddComponent<CanvasRaycastTarget>();
        
    }

    
}
