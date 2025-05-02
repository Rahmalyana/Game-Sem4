using UnityEngine;
using UnityEngine.SceneManagement;
public class HalamanManager : MonoBehaviour
{
    public string EnterScene;     
    public string EscapeScene;      
    public bool isEscapeForQuit = false;

    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            Debug.Log("Name Scene: " + EnterScene);
            SceneManager.LoadScene(EnterScene);
        }
 
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeForQuit)
            {
                Application.Quit();
            }
            else
            {
                Debug.Log("Name Scene: " + EscapeScene);
                SceneManager.LoadScene(EscapeScene);
            }
        }
    }
    public void Home() 
    { 
        SceneManager.LoadScene("Home"); 
    } 
    public void Play() 
    { 
        SceneManager.LoadScene("MenuPlay"); 
    } 
    public void Credit()
    { 
        SceneManager.LoadScene("MenuCredit"); 
    } 
    public void Exit()
    { 
        SceneManager.LoadScene("MenuExit"); 
    } 
    public void Game1() 
    { 
        SceneManager.LoadScene("Game1"); 
    } 
    public void Game2()
    { 
        SceneManager.LoadScene("Mode"); 
    }
    public void MulaiPermainan()
    {
        SceneManager.LoadScene("Game2 (Baru)");
    }
    public void MulaiVsAI()
    {
        SceneManager.LoadScene("Game2 VSAI"); 
    } 
    public void Game3()
    { 
        SceneManager.LoadScene("Game3"); 
    }
    public void KembaliKeMenu()
    {
        SceneManager.LoadScene("Mode");
    }
    public void KembaliKeMenuPlay()
    {
        SceneManager.LoadScene("MenuPlay");
    }
}
