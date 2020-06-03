using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //Used from JunoGame5 scripts - testing 3.6.2020
    void OnGUI()
    {
        //if retry button is pressed load scene 0 the game
        GUI.contentColor = Color.red;
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 150, 100, 40), "Retry?"))
        {
            //Application.LoadLevel(0);
            SceneManager.LoadScene("GamePlay");
        }
        //and quit button
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 200, 100, 40), "Quit"))
        {
            Application.Quit();
        }
    }
}
