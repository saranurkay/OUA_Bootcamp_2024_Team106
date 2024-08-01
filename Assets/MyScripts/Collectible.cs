using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int value = 1;

    void OnMouseDown()
    {
        Debug.Log("Elmas týklandý!"); // Týklama olayýný konsola yazdýr
        GameManager.instance.CollectDiamond(value);
        Destroy(gameObject); // Elmas yok edilir
    }
}


