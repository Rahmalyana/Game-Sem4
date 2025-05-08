using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NyawaVisual : MonoBehaviour
{
    public GameObject[] hearts;
    private float gameTime = 60f;
    public Text timerText;
    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    void Update()
    {
        // Pastikan nyawa tetap di batas 0-3
        int nyawa = Mathf.Clamp(Data.nyawa, 0, 3);

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < nyawa);
        }
    
        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;
            UpdateTimerDisplay();

            if (gameTime <= 0)
            {
                gameTime = 0;
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
