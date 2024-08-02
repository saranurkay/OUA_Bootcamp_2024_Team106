using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneName = "Piramit";
    public int requiredDiamonds =0; // Gereken elmas sayýsý
    public int requiredTrash =0; // Gereken çöp sayýsý

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = GameManager.instance;
            if (gameManager != null)
            {
                if (gameManager.GetDiamondCount() >= requiredDiamonds && gameManager.GetTrashCount() >= requiredTrash)
                {
                    SceneManager.LoadScene(sceneName);
                }
                else
                {
                    Debug.Log("Gerekli sayýda elmas ve çöp toplanmadý!");
                }
            }
        }
    }
}
