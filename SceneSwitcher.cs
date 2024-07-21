using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    //Portal etiketli kapidan gecince yeni bir haritaya gitmemizi sagliyor
    public string sceneToLoad;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
