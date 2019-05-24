using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public TextMeshProUGUI writtenName;

    private StreamWriter sw = null;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void EndedGame()
    {
        string name = writtenName.text;
        int points = BartenderController.points;

        string recordsFile = Application.persistentDataPath + "/records.txt";

        try
        {
            using (sw = new StreamWriter(recordsFile, true))
            {
                sw.WriteLine(name);
                sw.WriteLine(points);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        GoToMenu();
    }
}
