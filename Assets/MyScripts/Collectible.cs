using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int value = 1;

    void OnMouseDown()
    {
        Debug.Log("Elmas t�kland�!"); // T�klama olay�n� konsola yazd�r
        GameManager.instance.CollectDiamond(value);
        Destroy(gameObject); // Elmas yok edilir
    }
}


