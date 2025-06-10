using UnityEngine;
using TMPro;

public class GoalZone : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int score;

    private void Awake()
    {
        score = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
}
