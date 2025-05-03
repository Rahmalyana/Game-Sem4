using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Backsound : MonoBehaviour
{
    private AudioSource audioSource;

    private string[] allowedScenes = { "Home", "MenuPlay", "MenuCredit", "MenuExit", "Mode" };

    void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Music");

        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
        CheckScene(SceneManager.GetActiveScene().name); // cek saat start juga
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckScene(scene.name);
    }

    void CheckScene(string sceneName)
    {
        if (System.Array.Exists(allowedScenes, element => element == sceneName))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
        }
    }
}
