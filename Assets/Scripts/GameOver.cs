using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public int playerscore;
    public TextMeshProUGUI guiText;
    pancam pancam;

    private void Start()
    {
        pancam = FindObjectOfType<pancam>();
    }

    public void OnEnable()
    {
        guiText.text = pancam.playerScore.ToString();
    }

    public void IsGameRetry()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
