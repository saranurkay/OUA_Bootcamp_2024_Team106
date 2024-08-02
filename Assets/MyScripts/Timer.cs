using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText; // Geri sayým gösterecek Text UI elemaný
    private float timeRemaining = 10 * 60; // 10 dakika (saniye cinsinden)
    private bool timerIsRunning = false;

    private void Start()
    {
        timerIsRunning = true; // Timer'ý baþlat
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                // Ekstra iþlem yapýlacaksa burada yapýlabilir (oyunun bitiþi gibi).
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(timeToDisplay, 0); // Negatif zamana düþmesini önlemek için

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
