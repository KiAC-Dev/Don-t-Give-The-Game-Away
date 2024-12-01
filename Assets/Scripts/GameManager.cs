using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private GiftCollector giftCollector;
    [SerializeField] private TextMeshProUGUI timerUI;

    private void Start()
    {
        timer = 0;
        if(giftCollector == null) giftCollector = GameObject.Find("ItemTracker").GetComponent<GiftCollector>();
        if (timerUI == null) timerUI = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        timerUI.text = GetTime();
        if (giftCollector.presentsCollected >= 5) WinGame();
        if (timer > 300) LoseGame();
    }

    public void LoseGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #endif
        
        //Enter game over screen.
        Application.Quit();
    }

    public void WinGame()
    {
        SceneManager.LoadScene("Endscreen");
        gameObject.SetActive(false);
    }

    private string GetTime()
    {
        int minute = 4 - Mathf.FloorToInt(timer / 60);
        int seconds = 59 - Mathf.FloorToInt(timer % 60);
        string firstDigit = seconds < 10 ? "0" : "";

        return minute + ":" + firstDigit + seconds;
    }
}
