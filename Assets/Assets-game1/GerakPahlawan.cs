using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakPahlawan : MonoBehaviour
{
    int[] posX = new int[] { 0, -20, -40, -60, -80, -100, -120, -140, -160 };
    int idx = 0;
    public AudioSource[] audio;

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
            sources[i].volume = (i == 0) ? 2.0f : 0.1f; // Atur volume: audio[0] keras, audio[1] pelan
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
}
