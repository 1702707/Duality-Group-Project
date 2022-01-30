using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeethController : MonoBehaviour
{

    bool paused;
    public Animator[] anitmators;
    // Start is called before the first frame update
    void Start()
    {
        anitmators = GetComponentsInChildren<Animator>();
        foreach(Animator a in anitmators)
        {
            a.SetFloat("Speed", 1);
        }
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                //Hurt Player
            }
        }
    }

    public void Pause()
    {
        paused = !paused;
        if (paused)
        {
            foreach (Animator a in anitmators)
            {
                a.SetFloat("Speed", 0);
            }
        }
        else
        {
            foreach (Animator a in anitmators)
            {
                a.SetFloat("Speed", 1);
            }
        }
    }
}
