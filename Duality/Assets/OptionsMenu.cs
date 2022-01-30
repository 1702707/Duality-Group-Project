using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    Resolution[] resolutions;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public Slider VolumeSlider;
    public AudioMixer mixer;
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentIndex = 0;
        //populate resolution dropdown
        for (int i = 0; i < resolutions.Length; i++)
        {
            string name = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(name);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentIndex;
        resolutionDropdown.RefreshShownValue();
        float sfxVol;
        mixer.GetFloat("MasterVolume", out sfxVol);
        VolumeSlider.value = sfxVol;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //set Wwise music audio volume
    public void setVolume(float volume)
    {
        mixer.SetFloat("MasterVolume", volume);
    }

    //set screen resolution
    public void setResolution(int index)
    {
        Screen.SetResolution(resolutions[index].width, resolutions[index].height, Screen.fullScreen);
    }
    //toggle fullscreen
    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    //return from game to main menu
    public void ReturnToMenu()
    {
        //unlock cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //change scene
        SceneManager.LoadScene("MenuScene");
    }

    public void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

}
