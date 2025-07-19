using TMPro;
using UnityEngine;

public class ScoreManagers : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoreText;
    int score = 0;

    public void IncreaseScore(int amount)
    {
        // if (gameManager.ReturnGameOver()) return;
        if (gameManager.GameOver) return;
        score += amount;
        scoreText.text = score.ToString();
    }
}
