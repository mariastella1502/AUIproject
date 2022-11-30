using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip asteroidImpact, continuousBeam, reloading, uranusExplosion;
    static AudioSource audioSrc; 

    // Start is called before the first frame update
    void Start()
    {
        asteroidImpact = Resources.Load<AudioClip>("asteroidImpact");
        continuousBeam = Resources.Load<AudioClip>("continuous_beam_1");
        reloading = Resources.Load<AudioClip>("reloading_008");
        uranusExplosion = Resources.Load<AudioClip>("UranusExplosion");
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "impact" :
                audioSrc.PlayOneShot(asteroidImpact);
                break;
            case "beam":
                audioSrc.PlayOneShot(continuousBeam);
                break;
            case "uranusExplosion":
                audioSrc.PlayOneShot(uranusExplosion);
                break;
            case "reloading":
                audioSrc.PlayOneShot(reloading);
                break;
        }
    }

}
