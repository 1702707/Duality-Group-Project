using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject blocker;
    public Image image;
    public Sprite play;
    public Sprite pause;
    bool paused;
    public PlayerController player;
    public EnemyController[] Eyes;
    public TeethController[] Teeth;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        StartCoroutine(DisableBlocker());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DisableBlocker()
    {
        yield return new WaitForSeconds(13.0f);
        blocker.SetActive(false);
    }

    public void ToggleGameState()
    {
        paused = !paused;
        if (paused)
        {
            image.sprite = play;
        }
        else
        {
            image.sprite = pause;
        }
        foreach (EnemyController e in Eyes)
        {
            e.Pause();
        }
        foreach (TeethController t in Teeth)
        {
            t.Pause();
        }
    }
}
