using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class logicScript : MonoBehaviour
{


    public GameObject gameOverScreen;
    public BirdScript bird;
    public GameObject pauseMenu;
    public bool gameIsPaused = false;
    public GameObject darkBG;

    public List<int> grades = new List<int>();
    public float mean;
    public TextMeshProUGUI meanText;

    public int passedWeeks = 0;
    public TextMeshProUGUI currentMonth;
    public int monthLenght = 2;
    private int indexOfCurrentMonth = 0;
    private string[] monthNames = { "Settembre", "Ottobre", "Novembre", "Dicembre", "Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno" };

    public GameObject endOfLevel;

    public float behaviour;
    public TextMeshProUGUI behaviourText;
    public TextMeshProUGUI endOfLevelTitleText;
    public TextMeshProUGUI endOfLevelSubtitleText;
    public TextMeshProUGUI endOfLevelBodyText;


    public void AddWeek(int week)
    {
        if (bird.birdIsAlive)
        {
            passedWeeks += week;
            if (passedWeeks == monthLenght)
            {
                if (indexOfCurrentMonth < 9)
                {
                    passedWeeks = 0;
                    indexOfCurrentMonth += 1;
                    currentMonth.text = monthNames[indexOfCurrentMonth];
                }
                else
                {
                    EndOfLevel();
                }
            }
        }
    }

    public void EndOfLevel()
    {
        Time.timeScale = 0;
        gameIsPaused = true;
        endOfLevel.SetActive(true);

        if (behaviour > 5)
        {
            endOfLevelTitleText.text = "Promosso!";
            endOfLevelSubtitleText.text = "Ottimo lavoro!";
            endOfLevelBodyText.color = new Color32(39, 241, 6, 255);
            endOfLevelBodyText.text = "Media dei voti: " + mean.ToString("F1") + "\nCondotta: " + behaviour + "\n\nMedia totale: " + ((mean + behaviour) / 2).ToString("F1");
        }
        else
        {
            endOfLevelTitleText.text = "Bocciato!";
            endOfLevelSubtitleText.text = "Troppe assenze strategiche: devi farti interrogare di più!";
            endOfLevelBodyText.color = new Color32(241, 40, 6, 255);
            endOfLevelBodyText.text = "Media dei voti: " + mean.ToString("F1") + "\nCondotta: " + behaviour + "\n\nMedia totale: " + ((mean + behaviour) / 2).ToString("F1");
        }
    }



    public void AddGradeToMean(int grade)
    {
        grades.Add(grade);
        float gradeSum = 0;
        float numberOfGrades = 0;
        foreach (var g in grades)
        {
            numberOfGrades += 1;
            gradeSum += g;
        }
        if (numberOfGrades <= 10)
        {
            behaviour = numberOfGrades;
            behaviourText.text = "Condotta: " + behaviour.ToString();
        }

        mean = gradeSum / numberOfGrades;
        meanText.text = "Media dei voti: " + mean.ToString("F1");
    }




    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void GameOver()
    {
        bird.birdIsAlive = false;
        gameOverScreen.SetActive(true);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
        darkBG.SetActive(true);

    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        darkBG.SetActive(false);

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        gameIsPaused = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


}
