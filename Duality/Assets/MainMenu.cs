using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject blocker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        StartCoroutine(startGame());
    }
    IEnumerator startGame()
    {
        blocker.SetActive(true);
        //Wait
        yield return new WaitForSeconds(1.2f);
        //swap to new scene
        SceneManager.LoadScene("GameScene");
    }
    //Exit application
    public void Quit()
    {
        Application.Quit();
    }

}
