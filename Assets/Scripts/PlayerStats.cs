using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int score;
    [SerializeField] private TextMeshProUGUI scoreCounter;

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreCounter) scoreCounter.text = $"Score: {score}";
    }
}