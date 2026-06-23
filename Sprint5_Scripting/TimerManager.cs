using UnityEngine;
using System.Collections;
using System;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance { get; private set; }

    [Header("Timer Settings")]
    public float countdownDuration = 60f; // Default countdown time
    public bool isCountdownActive = false;
    public bool isStopwatchActive = false;

    private float currentCountdownTime;
    private float currentStopwatchTime;

    public event Action<float> OnCountdownTick;
    public event Action OnCountdownFinished;
    public event Action<float> OnStopwatchTick;

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

    void Start()
    {
        ResetCountdown();
        ResetStopwatch();
    }

    void Update()
    {
        if (isCountdownActive)
        {
            currentCountdownTime -= Time.deltaTime;
            OnCountdownTick?.Invoke(currentCountdownTime);

            if (currentCountdownTime <= 0)
            {
                currentCountdownTime = 0;
                isCountdownActive = false;
                OnCountdownFinished?.Invoke();
                Debug.Log("Countdown Finished!");
            }
        }

        if (isStopwatchActive)
        {
            currentStopwatchTime += Time.deltaTime;
            OnStopwatchTick?.Invoke(currentStopwatchTime);
        }
    }

    public void StartCountdown(float duration)
    {
        countdownDuration = duration;
        ResetCountdown();
        isCountdownActive = true;
        Debug.Log($"Countdown Started for {countdownDuration} seconds.");
    }

    public void StartCountdown()
    {
        StartCountdown(countdownDuration);
    }

    public void StopCountdown()
    {
        isCountdownActive = false;
        Debug.Log("Countdown Stopped.");
    }

    public void ResetCountdown()
    {
        currentCountdownTime = countdownDuration;
        isCountdownActive = false;
        OnCountdownTick?.Invoke(currentCountdownTime);
    }

    public float GetCurrentCountdownTime()
    {
        return currentCountdownTime;
    }

    public void StartStopwatch()
    {
        ResetStopwatch();
        isStopwatchActive = true;
        Debug.Log("Stopwatch Started.");
    }

    public void StopStopwatch()
    {
        isStopwatchActive = false;
        Debug.Log("Stopwatch Stopped.");
    }

    public void ResetStopwatch()
    {
        currentStopwatchTime = 0f;
        isStopwatchActive = false;
        OnStopwatchTick?.Invoke(currentStopwatchTime);
    }

    public float GetCurrentStopwatchTime()
    {
        return currentStopwatchTime;
    }
}
