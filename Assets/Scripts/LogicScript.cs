using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class logicScript : MonoBehaviour
{

    public SpriteRenderer birdSprite;
    public Sprite deadBird;

    public GameObject gameOverScreen;
    public BirdScript bird;
    public GameObject pauseMenu;
    public PlayerStats playerStats;
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
    public GameObject nextLevelButton;
    public float behaviour;
    public TextMeshProUGUI behaviourText;
    public TextMeshProUGUI endOfLevelTitleText;
    public TextMeshProUGUI endOfLevelSubtitleText;
    public TextMeshProUGUI endOfLevelBodyText;
    public float maxBehaviour;

    public GameObject blackBoard;
    public Sprite[] birdpics;
    public UnityEngine.UI.Image choosenBirdPic;

    public void Start()
    {
        Time.timeScale = 0;
        gameIsPaused = true;
        blackBoard.SetActive(true);
    }

    public void BlackBoardContinue()
    {
        Time.timeScale = 1;
        gameIsPaused = false;
        blackBoard.SetActive(false);
    }


    public void AbbassaCondotta()
    {
        if (maxBehaviour >= 3)
        {
            maxBehaviour -= 1f;
        }
        if (behaviour > maxBehaviour)
        {
            behaviour = maxBehaviour;
        }
        behaviourText.text = "Condotta: " + behaviour.ToString() + "/" + maxBehaviour;
    }


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
        AudioManager.instance.PlayMusic("ScoreScreen");
        PlayerStats.instance.AddToMean(mean);

        if (mean >= 6 && behaviour >= 6)
        {
            choosenBirdPic.sprite = birdpics[0];

            if (PlayerStats.instance.currentLevel == 6 && PlayerStats.instance.finalGrade >= 60)
            {
                endOfLevelTitleText.text = "Finalmente maturo!";
                endOfLevelSubtitleText.text = "È stata dura ma ce l'hai fatta!";
                endOfLevelBodyText.color = new Color32(39, 241, 6, 255);
                endOfLevelBodyText.text = "Voto finale dell'esame di stato: " + Mathf.RoundToInt(PlayerStats.instance.finalGrade);
            }
            else
            {
                nextLevelButton.SetActive(true);
                endOfLevelTitleText.text = "Promosso!";
                endOfLevelSubtitleText.text = "Ottimo lavoro!";
                endOfLevelBodyText.color = new Color32(39, 241, 6, 255);
                endOfLevelBodyText.text = "Media dei voti: " + mean.ToString("F1") + "\nCondotta: " + behaviour + "\n\nMedia totale: " + ((mean + behaviour) / 2).ToString("F1");
            }
        }
        else
        {
            choosenBirdPic.sprite = birdpics[1];
            string testo = "Che hai fatto!!??";
            if (behaviour < 6 && mean < 6)
            {
                testo = "Bro, sei un disastro!";
            }
            else if (behaviour >= 6 && mean < 6)
            {
                testo = "Insufficienze non sanabili in Scienze, Inglese, Matematica, Filosofia, Informatica, Latino, Greco, Esperanto, Musica, TEC, TAC, Tik-tok, Instagram e cucito. Il Consiglio di Classe ha deliberato la non ammissione alla classe successiva.";
            }
            else if (behaviour < 6 && mean >= 6)
            {
                testo = "Forse non avresti dovuto usare ciò che hai imparato in fisica per creare quell\'esplosivo…";
            }
            endOfLevelTitleText.text = "Bocciato!";
            nextLevelButton.SetActive(false);
            endOfLevelSubtitleText.text = testo;
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
        if (numberOfGrades <= maxBehaviour)
        {
            behaviour = numberOfGrades;
            behaviourText.text = "Condotta: " + behaviour.ToString() + "/" + maxBehaviour;
        }

        mean = gradeSum / numberOfGrades;
        meanText.text = "Media dei voti: " + mean.ToString("F1");
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene("Level" + PlayerStats.instance.currentLevel);
        AudioManager.instance.PlayMusic("Level");
    }




    public void RestartGame()
    {
        if (bird.birdIsAlive)
        {
            PlayerStats.instance.RemoveToMean();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioManager.instance.PlayMusic("Level");
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void GameOver()
    {
        bird.birdIsAlive = false;
        bird.animator.enabled = false;
        birdSprite.sprite = deadBird;
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
