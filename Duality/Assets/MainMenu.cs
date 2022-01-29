using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
        //Wait
        yield return new WaitForSeconds(0.1f);
        //swap to new scene
        SceneManager.LoadScene("GameScene");
    }
    //Exit application
    public void Quit()
    {
        Application.Quit();
    }

}
