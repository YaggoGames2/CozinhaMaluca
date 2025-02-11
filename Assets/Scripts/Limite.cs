
using UnityEngine;

public class Limite : MonoBehaviour

{
    public GameObject objetoGamerOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Voador")
        {
            objetoGamerOver.SetActive(true);
        }
    }
} 
