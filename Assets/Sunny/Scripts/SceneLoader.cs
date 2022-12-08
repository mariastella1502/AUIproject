using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; //serve per gestire le scene

public class SceneLoader : MonoBehaviour
{

    // method che fa il loading della scena successiva
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    public void LoadUranusScene()
    {
        SceneManager.LoadScene(1);
    }


    //method che ritorna dall'ultima scena a quella iniziale
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);

    }

}
