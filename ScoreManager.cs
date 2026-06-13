using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("Scoring Parameters")]
    public int currentScore = 0;
    public int currentStars = 0;
    public int maxStars = 3;

    [Header("Reward Configuration")]
    public int baseReward = 100;
    public int starBonus = 50;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        Debug.Log($"Score: {currentScore}");
        // Update UI here
    }

    public void CalculateStars(float timeTaken, float damageTaken, float perfectParkingBonus = 0)
    {
        // Placeholder for complex star calculation logic
        // This would involve comparing timeTaken and damageTaken against target values
        // For simplicity, let's assign stars based on some arbitrary conditions for now

        currentStars = 0;
        if (timeTaken < 30f && damageTaken < 10f) // Example condition for 3 stars
        {
            currentStars = 3;
        }
        else if (timeTaken < 60f && damageTaken < 20f) // Example condition for 2 stars
        {
            currentStars = 2;
        }
        else if (timeTaken < 90f) // Example condition for 1 star
        {
            currentStars = 1;
        }

        currentStars = Mathf.Min(currentStars, maxStars); // Ensure stars don't exceed max
        Debug.Log($"Stars Earned: {currentStars}");
        // Update UI here
    }

    public int GetTotalReward()
    {
        int totalReward = baseReward + (currentStars * starBonus);
        Debug.Log($"Total Reward: {totalReward}");
        return totalReward;
    }

    public void ResetScore()
    {
        currentScore = 0;
        currentStars = 0;
    }
}
