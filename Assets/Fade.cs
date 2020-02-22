using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PlayerController player;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private float startDelay = 0.5f;
    [SerializeField] private float playerFreezeDelay = 0.5f;

    private float totalFadeTime;
    public float TotalFadeTime
    {
        get { return totalFadeTime; }
    }

    // Start is called before the first frame update
    void Start()
    {
        totalFadeTime = transitionTime + startDelay + 0.5f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(spriteRenderer.color.a == 1)
        {
            StartCoroutine(Transition());
        }
    }

    public IEnumerator Transition()
    {
        player.Freeze();
        yield return new WaitForSeconds(startDelay);

        float alpha = spriteRenderer.color.a;
        float delta = 0.1f / transitionTime;

        if (alpha >= 1)
            delta *= -1;            

        for (float t = 0; Mathf.Abs(t) < 1; t += delta)
        {
            alpha += delta;
            spriteRenderer.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(playerFreezeDelay);
        player.Unfreeze();
    }
}
