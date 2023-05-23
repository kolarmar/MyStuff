using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class KeyBind : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI moveLeftRedButton;
    [SerializeField] private TextMeshProUGUI moveRightRedButton;
    [SerializeField] private TextMeshProUGUI jumpRedButton;

    [SerializeField] private TextMeshProUGUI moveLeftBlueButton;
    [SerializeField] private TextMeshProUGUI moveRightBlueButton;
    [SerializeField] private TextMeshProUGUI jumpBlueButton;

    void Start()
    {
        // DEFAULT BINDS
        // Fireboy
        PlayerPrefs.SetString("MoveLeftRed", "LeftArrow");
        PlayerPrefs.SetString("MoveRightRed", "RightArrow");
        PlayerPrefs.SetString("JumpRed", "UpArrow");

        //Watergirl
        PlayerPrefs.SetString("MoveLeftBlue", "A");
        PlayerPrefs.SetString("MoveRightBlue", "D");
        PlayerPrefs.SetString("JumpBlue", "W");


        moveLeftRedButton.text = PlayerPrefs.GetString("MoveLeftRed");
        moveRightRedButton.text = PlayerPrefs.GetString("MoveRightRed");
        jumpRedButton.text = PlayerPrefs.GetString("JumpRed");

        moveLeftBlueButton.text = PlayerPrefs.GetString("MoveLeftBlue");
        moveRightBlueButton.text = PlayerPrefs.GetString("MoveRightBlue");
        jumpBlueButton.text = PlayerPrefs.GetString("JumpBlue");
    }

    void Update()
    {
        CheckButton(moveLeftRedButton, "MoveLeftRed");
        CheckButton(moveRightRedButton, "MoveRightRed");
        CheckButton(jumpRedButton, "JumpRed");

        CheckButton(moveLeftBlueButton, "MoveLeftBlue");
        CheckButton(moveRightBlueButton, "MoveRightBlue");
        CheckButton(jumpBlueButton, "JumpBlue");
    }

    public void ChangeKey(TextMeshProUGUI button)
    {
        button.text = "Awaiting input";
    }

    private void CheckButton(TextMeshProUGUI button, string keySaveValueName)
    {
        if (button.text == "Awaiting input")
        {
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keycode))
                {
                    button.text = keycode.ToString();
                    PlayerPrefs.SetString(keySaveValueName, keycode.ToString());
                    PlayerPrefs.Save();
                }
            }
        }
    }
}
