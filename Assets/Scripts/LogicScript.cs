using TMPro;
using UnityEngine;

public class logicScript : MonoBehaviour
{
    public int playerScore = 0;
    public TextMeshProUGUI scoreText;

    
public void AddScore()
    {
        playerScore += 1;
        scoreText.text = playerScore.ToString();
    }


}
