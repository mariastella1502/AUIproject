using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulateImageTracking : MonoBehaviour
{


    [SerializeField] public Button btn;
    [SerializeField] public Image img;

    private void Awake()
    {
        btn.interactable = false;

    }
    public void ImageTracked()
    {
        btn.interactable = true;
    }

    public void StartFading()
    {
        // fades the image out when you click
        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {

        // loop over 1 second
        for (float i = 0; i <= 255; i += Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(255, 255, 255, i);
            yield return null;
        }
    }
}
