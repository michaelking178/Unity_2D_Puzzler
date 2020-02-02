using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private Vector3 destination = new Vector3(0, 0, 0);
    [SerializeField] float speed = 3f;

    [HideInInspector] public bool isTransitioning = false;

    // Update is called once per frame
    void Update()
    {
        if (isTransitioning)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
        }
    }
}
