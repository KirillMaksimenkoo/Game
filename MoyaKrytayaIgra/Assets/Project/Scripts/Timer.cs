using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private int totalSeconds = 300;
    private TMP_Text _TimerText;
    [SerializeField] private int delta = 1;
    private bool timerActive = false;
    public Finish finish;

    void Start()
    {
        _TimerText = GameObject.Find("TimerText").GetComponent<TMP_Text>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MehanicObj"))
        {
            timerActive = true;
            StartCoroutine(ITimer());
            Destroy(other.gameObject);
        }
    }

    IEnumerator ITimer()
    {
        while (totalSeconds > 0 && timerActive)
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            _TimerText.text = minutes.ToString("D2") + " : " + seconds.ToString("D2");

            yield return new WaitForSeconds(delta);

            totalSeconds -= delta;
        }
        finish.LoseGame();
        Time.timeScale = 0f;
    }
}
