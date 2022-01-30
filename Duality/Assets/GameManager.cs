using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        
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
