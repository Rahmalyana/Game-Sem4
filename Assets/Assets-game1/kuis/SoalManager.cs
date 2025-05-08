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

    public void GantiSoal()
    {
        gambarPahlawan.sprite = gambarBaruPahlawan;
        jawaban1.sprite = jawabanBaru1;
        jawaban2.sprite = jawabanBaru2;
        jawaban3.sprite = jawabanBaru3;

        // Ganti target jawaban benar
    scriptBenarKuis.Jawaban = jawabanBenarBerikutnya;

        // reset posisi atau lock jika perlu
        benarKuis.locked = false;
    }
}
