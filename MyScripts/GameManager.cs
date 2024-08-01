using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text diamondText;
    public Text trashText; // ��p say�s�n� g�sterecek Text UI eleman�
    public Text timerText; // Geri say�m g�sterecek Text UI eleman�

    private int diamondCount = 0;
    private int trashCount = 0; // Toplanan ��p say�s�
    private float timeRemaining = 20 * 60; // 20 dakika (saniye cinsinden)
    private bool timerIsRunning = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        timerIsRunning = true;
        UpdateDiamondUI();
        UpdateTrashUI(); // Ba�lang��ta ��p say�s�n� g�ncelle
    }

    private void Update()
    {
        // Fare t�klamas�n� kontrol et
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Raycast ile t�klanan nesneyi kontrol et
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Elmas"))
                {
                    CollectDiamond(1);
                    Destroy(hit.transform.gameObject); // Elmas� yok et
                }
                else if (hit.transform.CompareTag("Cop"))
                {
                    CollectTrash(1);
                    Destroy(hit.transform.gameObject); // ��p� yok et
                }
            }
        }

        // Geri say�m sayac�n� kontrol et ve g�ncelle
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
                // Ekstra i�lem yap�lacaksa burada yap�labilir (oyunun biti�i gibi).
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(timeToDisplay, 0); // Negatif zamana d��mesini �nlemek i�in

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    public void CollectDiamond(int amount)
    {
        diamondCount += amount;
        UpdateDiamondUI();
    }

    public void CollectTrash(int amount)
    {
        trashCount += amount;
        UpdateTrashUI();
    }

    private void UpdateDiamondUI()
    {
        if (diamondText != null)
        {
            diamondText.text = "Diamonds: " + diamondCount;
        }
        else
        {
            Debug.LogWarning("diamondText referans� yok veya silinmi�!");
        }
    }

    private void UpdateTrashUI()
    {
        if (trashText != null)
        {
            trashText.text = "Trash: " + trashCount;
        }
        else
        {
            Debug.LogWarning("trashText referans� yok veya silinmi�!");
        }
    }
}

