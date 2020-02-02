using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player"){
            mainCamera.GetComponent<CameraPosition>().isTransitioning = true;
        }
    }
}
