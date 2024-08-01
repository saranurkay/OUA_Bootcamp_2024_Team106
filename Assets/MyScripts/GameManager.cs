using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text diamondText;
    public Text trashText; // Çöp sayýsýný gösterecek Text UI elemaný
    public Text timerText; // Geri sayým gösterecek Text UI elemaný

    private int diamondCount = 0;
    private int trashCount = 0; // Toplanan çöp sayýsý
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
        UpdateTrashUI(); // Baþlangýçta çöp sayýsýný güncelle
    }

    private void Update()
    {
        // Fare týklamasýný kontrol et
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Raycast ile týklanan nesneyi kontrol et
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Elmas"))
                {
                    CollectDiamond(1);
                    Destroy(hit.transform.gameObject); // Elmasý yok et
                }
                else if (hit.transform.CompareTag("Cop"))
                {
                    CollectTrash(1);
                    Destroy(hit.transform.gameObject); // Çöpü yok et
                }
            }
        }

        // Geri sayým sayacýný kontrol et ve güncelle
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
            Debug.LogWarning("diamondText referansý yok veya silinmiþ!");
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
            Debug.LogWarning("trashText referansý yok veya silinmiþ!");
        }
    }
}

