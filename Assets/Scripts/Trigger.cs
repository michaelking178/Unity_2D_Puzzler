using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private float pullPlayerTime = 1.25f;

    private bool isPullingPlayer = false;
    private bool isActivated = true;
    private PlayerController player;
    private ColorManager colorManager;
    private SpriteRenderer spriteRenderer;
    private Color color;

    private void Start()
    {
        colorManager = FindObjectOfType<ColorManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
    }

    private void Update()
    {
        if (player != null && isPullingPlayer)
        {
            player.transform.position = Vector2.MoveTowards((Vector2)player.transform.position, transform.position, Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && isActivated)
        {
            player = col.gameObject.GetComponent<PlayerController>();
            StartCoroutine(PullPlayer());
        }
    }

    private IEnumerator PullPlayer()
    {
        player.canMove = false;
        isPullingPlayer = true;
        yield return new WaitForSeconds(pullPlayerTime);
        player.GetComponent<SpriteRenderer>().color = colorManager.CombineColors(player.spriteRenderer.color, color);
        Deactivate();
    }

    private void Deactivate()
    {
        isPullingPlayer = false;
        isActivated = false;
        player.canMove = true;
        GetComponent<SpriteRenderer>().color = Color.gray;
    }
}
