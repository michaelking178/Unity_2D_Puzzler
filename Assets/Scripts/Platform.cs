using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Vector2 startPos = new Vector2(0, 0);
    [SerializeField] private Vector2 endPos = new Vector2(0, 0);
    [SerializeField] private float speed = 3f;

    private bool isGoingToEndPos = true;
    private Color color;
    private ColorManager colorManager;

    void Start()
    {
        colorManager = FindObjectOfType<ColorManager>();
        color = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2)transform.position == endPos)
        {
            isGoingToEndPos = false;
        }
        else if ((Vector2)transform.position == startPos)
        {
            isGoingToEndPos = true;
        }

        if (isGoingToEndPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos, Time.fixedDeltaTime * speed);
        }
        else 
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, Time.fixedDeltaTime * speed);
        }
    }
}
