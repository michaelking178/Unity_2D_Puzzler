using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expandor : MonoBehaviour
{
    [SerializeField] private Vector2 startScale = new Vector2(0, 0);
    [SerializeField] private Vector2 endScale = new Vector2(0, 0);
    [SerializeField] private float speed = 3f;
    [SerializeField] private float stopDelay = 1f;

    private bool isGoingToEndScale = true;
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
        if ((Vector2)transform.localScale == endScale && isGoingToEndScale)
        {
            StartCoroutine(Stop());
            isGoingToEndScale = false;
        }
        else if ((Vector2)transform.localScale == startScale && !isGoingToEndScale)
        {
            StartCoroutine(Stop());
            isGoingToEndScale = true;
        }

        if (isGoingToEndScale && !isStopped)
        {
            transform.localScale = Vector2.MoveTowards(transform.localScale, endScale, Time.fixedDeltaTime * speed);
        }
        else if (!isGoingToEndScale && !isStopped)
        {
            transform.localScale = Vector2.MoveTowards(transform.localScale, startScale, Time.fixedDeltaTime * speed);
        }
    }

    private IEnumerator Stop()
    {
        isStopped = true;
        yield return new WaitForSeconds(stopDelay);
        isStopped = false;
    }
}
