using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text currentScoreText;
    void Start()
    {
        Data.nyawa = 3;
        // Tampilkan skor saat ini
        currentScoreText.text = "Skor: " + Data.score;
        Data.score = 0;
    }

    public void UlangiPermainan()
    {
        Data.score = 0;
        SceneManager.LoadScene("Game3"); // nama scene gameplay kamu
    }

    public void KembaliKeMenu()
    {
        Data.score = 0;
        SceneManager.LoadScene("MenuPlay");
    }
}