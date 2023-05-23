using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    private TextMeshProUGUI levelText;
    private void Start()
    {
        levelText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OpenLevel()
    {
        SceneManager.LoadScene("Level_" + levelText.text);
    }
}
