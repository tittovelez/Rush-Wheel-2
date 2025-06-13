using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public float timeRemaining = 60f;
    public TextMeshProUGUI timerText;

    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                GameOver();
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(timeToDisplay, 0);
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("¡Tiempo agotado! Has perdido.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // ➡️ Nueva función para restar tiempo
    public void SubtractTime(float amount)
    {
        timeRemaining -= amount;
        if (timeRemaining < 0)
        {
            timeRemaining = 0;
        }
    }
}
