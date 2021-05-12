using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    public Button startButton;

    public void StartGame()
    {
        SceneManager.LoadScene("Main",LoadSceneMode.Single);
        
    }

    public void GameOver()
    {
        startButton.GetComponentInChildren<TextMeshProUGUI>().text = "RESTART";
    }
}
