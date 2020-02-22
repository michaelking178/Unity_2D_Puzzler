using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private string levelToLoad = "";

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            StartCoroutine(GameObject.FindObjectOfType<LevelManager>().LoadLevel(levelToLoad));
        }
    }
}
