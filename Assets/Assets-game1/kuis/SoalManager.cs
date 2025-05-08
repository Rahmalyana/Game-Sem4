using UnityEngine;

public class SoalManager : MonoBehaviour
{
    public SpriteRenderer gambarPahlawan;
    public SpriteRenderer jawaban1;
    public SpriteRenderer jawaban2;
    public SpriteRenderer jawaban3;

    public Sprite gambarBaruPahlawan;
    public Sprite jawabanBaru1;
    public Sprite jawabanBaru2;
    public Sprite jawabanBaru3;

    public Transform jawabanBenarBerikutnya;
    public benarKuis scriptBenarKuis;

    public int nomorSoal = 1;
    public int totalSoal = 2;


    public void GantiSoal()
{
    if (nomorSoal < totalSoal)
    {
        nomorSoal++;

        gambarPahlawan.sprite = gambarBaruPahlawan;
        jawaban1.sprite = jawabanBaru1;
        jawaban2.sprite = jawabanBaru2;
        jawaban3.sprite = jawabanBaru3;

        scriptBenarKuis.Jawaban = jawabanBenarBerikutnya;
        scriptBenarKuis.ResetPosisi();
        benarKuis.locked = false;
    }
    // Jika sudah soal terakhir, tidak lakukan apa-apa (atau bisa trigger winText di sini juga)
}

}
