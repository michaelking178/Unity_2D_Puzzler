using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    private Vector3 destination;

    void Start()
    {
        destination = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
    }

    public void SetDestination(Vector3 dest)
    {
        destination = dest;
    }
}
