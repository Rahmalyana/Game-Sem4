using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonyetController : MonoBehaviour
{
    public float kecepatan;
    public string verticalAxis;
    public string horizontalAxis;
    public float batasAtas;
    public float batasBawah;
    public float batasKiri;
    public float batasKanan;
    public float batasTengah; 

    void Update()
    {
        float gerakVertikal = Input.GetAxis(verticalAxis) * kecepatan * Time.deltaTime;
        float gerakHorizontal = Input.GetAxis(horizontalAxis) * kecepatan * Time.deltaTime;

        float nextPosY = transform.position.y + gerakVertikal;
        float nextPosX = transform.position.x + gerakHorizontal;

        // Batas atas-bawah
        if (nextPosY > batasAtas || nextPosY < batasBawah)
        {
            gerakVertikal = 0;
        }

        // Batas kiri-kanan umum
        if (nextPosX > batasKanan || nextPosX < batasKiri)
        {
            gerakHorizontal = 0;
        }

        // Batas tengah supaya tidak menyeberang
        if (gameObject.name == "Monyet Kiri" && nextPosX > batasTengah)
        {
            gerakHorizontal = 0;
        }
        else if (gameObject.name == "Monyet Kanan" && nextPosX < batasTengah)
        {
            gerakHorizontal = 0;
        }

        // Gerakkan paddle
        transform.Translate(gerakHorizontal, gerakVertikal, 0);
    }
}
