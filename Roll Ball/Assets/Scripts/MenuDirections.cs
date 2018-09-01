using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDirections : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene("Map01");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
