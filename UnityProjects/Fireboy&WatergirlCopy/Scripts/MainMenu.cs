using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject controlsScreen;
    [SerializeField] private GameObject levelSelectScreen;
    public void PlayClicked()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void LevelsClicked()
    {
        levelSelectScreen.SetActive(true);
    }

    public void ControlsClicked()
    {
        controlsScreen.SetActive(true);
    }

    public void BackButtonClicked()
    {
        controlsScreen.SetActive(false);
        levelSelectScreen.SetActive(false);
    }
    public void ExitClicked()
    {
        Application.Quit();
    }


}
