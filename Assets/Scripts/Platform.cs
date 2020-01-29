using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Vector2 startPos = new Vector2(0, 0);
    [SerializeField] private Vector2 endPos = new Vector2(0, 0);
    [SerializeField] private float speed = 3f;
    [SerializeField] private float stopDelay = 1f;

    private bool isGoingToEndPos = true;
    private bool isStopped = false;
    private Color color;
    private ColorManager colorManager;

    void Start()
    {
        colorManager = FindObjectOfType<ColorManager>();
        color = GetComponent<SpriteRenderer>().color;
        StartCoroutine(Stop());
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2)transform.position == endPos && isGoingToEndPos)
        {
            StartCoroutine(Stop());
            isGoingToEndPos = false;
        }
        else if ((Vector2)transform.position == startPos && !isGoingToEndPos)
        {
            StartCoroutine(Stop());
            isGoingToEndPos = true;
        }

        if (isGoingToEndPos && !isStopped)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos, Time.fixedDeltaTime * speed);
        }
        else if (!isGoingToEndPos && !isStopped)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, Time.fixedDeltaTime * speed);
        }
    }

    private IEnumerator Stop()
    {
        isStopped = true;
        yield return new WaitForSeconds(stopDelay);
        isStopped = false;
    }
}
