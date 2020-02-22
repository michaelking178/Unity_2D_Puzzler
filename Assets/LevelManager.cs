using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager levelManager;
    private bool isEnabled = false;

    void Awake()
    {
        if (levelManager == null)
        {
            levelManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public IEnumerator LoadLevel(string levelName)
    {
        Fade fadeCurtain = GameObject.Find("FadeCurtain").GetComponent<Fade>();
        StartCoroutine(fadeCurtain.Transition());
        yield return new WaitForSeconds(fadeCurtain.TotalFadeTime + 1f);
        SceneManager.LoadScene(levelName);
    }
}
