using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakPahlawan : MonoBehaviour
{
    int[] posX = new int[] {0, -20, -40, -60, -80, -100, -120, -140, -160}; 
    int idx = 0; 
    public AudioSource[] audio; 
    // Start is called before the first frame update
    void Start()
    {
        audio[idx].Play(); 
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyUp(KeyCode.RightArrow)) 
        { 
            if (idx < posX.Length - 1) 
            { 
                audio[idx].Stop(); 
                idx++; 
                audio[idx].Play(); 
            } 
        } 
        if (Input.GetKeyUp(KeyCode.LeftArrow)) 
        { 
            if (idx > 0) 
            { 
                audio[idx].Stop(); 
                idx--; 
                audio[idx].Play(); 
            } 
        } 
        transform.position = Vector3.MoveTowards(transform.position, new 
Vector3(posX[idx], transform.position.y), 50 * Time.deltaTime); 
    }
}
