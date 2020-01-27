using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private bool isQuitButton = false;
    [SerializeField] private string levelToLoad = "";

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (isQuitButton)
            {
                Debug.Log("Quitting game...");
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }
}
