using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;
using UnityEngine.UI;

public class TrackingImageVisualizer : MonoBehaviour
{

    public NRTrackableImage image;
    public GameObject cube;
    public Button marsButton, uranusButton;
    public Image img;
    private void Update()
    {
        if (image == null)
        {
            cube.SetActive(false);
            //marsButton.interactable = false;
            //uranusButton.interactable = false;
            return;
        }
        var center = image.GetCenterPose();
        transform.position = center.position;
        transform.rotation = center.rotation;
        cube.SetActive(true);


        /*
         if(image.GetDataBaseIndex() == 0)
         {

             //attiva bottone gioco marte
             img = marsButton.GetComponent<Image>();
             StartFading();
             marsButton.interactable = true;
         }
         else if (image.GetDataBaseIndex() == 1)
         {
             //attiva bottone gioco urano
             img = uranusButton.GetComponent<Image>();
             StartFading();
             uranusButton.interactable = true;

         }
         */


        //aggiungere qui il comando che rende un minigioco sbloccabile
    }

    public void StartFading()
    {
        // fades the image out when you click
        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {

        // loop over 1 second
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}