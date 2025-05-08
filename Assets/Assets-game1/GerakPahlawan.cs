using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerakPahlawan : MonoBehaviour
{
    int[] posX = new int[] { 0, -20, -40, -60, -80, -100, -120, -140, -160 };
    int idx = 0;
    public AudioSource[] audio;

    private Coroutine kuisCoroutine;
    private bool isReadyToLoad = false;
    private bool sudahPindah = false;

    void Start()
    {
        PlayCurrentAudio();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (idx < posX.Length - 1)
            {
                StopCurrentAudio();
                idx++;
                PlayCurrentAudio();

                if (idx == posX.Length - 1 && !isReadyToLoad)
                {
                    isReadyToLoad = true;
                    kuisCoroutine = StartCoroutine(PindahKeKuis());
                }
            }
            else if (idx == posX.Length - 1 && isReadyToLoad && !sudahPindah)
            {
                // Tekan RightArrow lagi di posisi terakhir => langsung pindah
                if (kuisCoroutine != null) StopCoroutine(kuisCoroutine);
                sudahPindah = true;
                SceneManager.LoadScene("Game1-kuis");
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (idx > 0)
            {
                StopCurrentAudio();
                idx--;
                PlayCurrentAudio();
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(posX[idx], transform.position.y), 50 * Time.deltaTime);
    }

    void PlayCurrentAudio()
    {
        AudioSource[] sources = audio[idx].gameObject.GetComponents<AudioSource>();
        for (int i = 0; i < sources.Length; i++)
        {
            sources[i].volume = (i == 0) ? 2.0f : 0.1f;
            sources[i].Play();
        }
    }

    void StopCurrentAudio()
    {
        AudioSource[] sources = audio[idx].gameObject.GetComponents<AudioSource>();
        foreach (AudioSource source in sources)
        {
            source.Stop();
        }
    }

    IEnumerator PindahKeKuis()
    {
        yield return new WaitForSeconds(15f); // tunggu 1.5 detik agar audio terakhir sempat main
        SceneManager.LoadScene("Game1-kuis");
    }
}
