using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject DeathScreen;
    [SerializeField] private GameObject WinScreen;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            WinScreen.SetActive(true);
            Destroy(other.gameObject);
            Time.timeScale = 0f;
        }
    }

    public void LoseGame()
    {
        DeathScreen.SetActive(true);
    }
}
