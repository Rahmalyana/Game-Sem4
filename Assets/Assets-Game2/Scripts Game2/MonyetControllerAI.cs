using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonyetControllerAI : MonoBehaviour
{
    public float kecepatan;
    public string verticalAxis;
    public string horizontalAxis;
    public float batasAtas;
    public float batasBawah;
    public float batasKiri;
    public float batasKanan;
    public float batasTengah;

    public bool isAI = false;
    public Transform bola;
    public Rigidbody2D bolaRigidbody;

    public float prediksiJarak = 1f;      // Jarak waktu ke depan untuk prediksi posisi bola
    public float toleransi = 0.3f;        // Supaya AI tidak selalu pas banget
    public float reaksiLambat = 0.85f;    // Seberapa cepat AI merespons (1 = sangat responsif)

    void Update()
    {
        float gerakVertikal = 0f;
        float gerakHorizontal = 0f;

        if (isAI && bola != null && bolaRigidbody != null && gameObject.name == "Monyet Kanan")
        {
            // Prediksi posisi bola beberapa waktu ke depan
            Vector2 prediksiPos = bola.position + (Vector3)(bolaRigidbody.velocity * prediksiJarak);

            float targetY = Mathf.Clamp(prediksiPos.y, batasBawah + 0.5f, batasAtas - 0.5f);
            float selisihY = targetY - transform.position.y;

            // AI bergerak ke target dengan kecepatan dibatasi + reaksi lambat
            if (Mathf.Abs(selisihY) > toleransi)
            {
                float arah = Mathf.Sign(selisihY);
                gerakVertikal = arah * kecepatan * reaksiLambat * Time.deltaTime;
            }
        }
        else
        {
            // Manual player
            gerakVertikal = Input.GetAxis(verticalAxis) * kecepatan * Time.deltaTime;
            gerakHorizontal = Input.GetAxis(horizontalAxis) * kecepatan * Time.deltaTime;
        }

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
