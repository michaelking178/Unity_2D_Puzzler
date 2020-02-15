using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Vector2 unlockPositionOffset = new Vector2();
    [SerializeField] private float doorOpenDelay = 1.25f;
    [SerializeField] private float doorOpenSpeed = 2f;
    public Color color;

    private PlayerController player;
    private bool isUnlocking = false;
    private Vector2 unlockPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        unlockPosition = new Vector2(transform.position.x + unlockPositionOffset.x, transform.position.y + unlockPositionOffset.y);

        color = GetComponent<SpriteRenderer>().color;
        color.r = (float)System.Math.Round(color.r, 2);
        color.g = (float)System.Math.Round(color.g, 2);
        color.b = (float)System.Math.Round(color.b, 2);
        GetComponent<SpriteRenderer>().color = color;
    }

    void FixedUpdate()
    {
        if (isUnlocking)
        {
            transform.position = Vector2.MoveTowards(transform.position, unlockPosition, Time.deltaTime * doorOpenSpeed);
        }
    }    

    public void Deactivate()
    {
        StartCoroutine(Unlock());
    }

    private IEnumerator Unlock()
    {
        player.canControlMovement = false;
        isUnlocking = true;
        yield return new WaitForSeconds(doorOpenDelay);
        player.canControlMovement = true;
        isUnlocking = false;
        Destroy(gameObject);
    }
}
