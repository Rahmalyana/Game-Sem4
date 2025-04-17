using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public int force = 500;
    Rigidbody2D rigid;

    private bool menyentuhTepiKanan = false;
    private bool menyentuhTepiKiri = false;

    private int skorKiri = 0;
    private int skorKanan = 0;

    public Text scoreKiriText;
    public Text scoreKananText;

    // Tambahan untuk Game Over
    public GameObject panelSelesai;
    public Text pemenangText;

    // Tambahan untuk suara
    public AudioSource audioSource;
    public AudioClip hitSound;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>(); // Inisialisasi AudioSource

        UpdateScoreUI();
        panelSelesai.SetActive(false); // Sembunyikan panel di awal
        StartGame();
    }

    void StartGame()
    {
        transform.localPosition = Vector2.zero;
        rigid.velocity = Vector2.zero;

        Vector2 arah = new Vector2(1, 0).normalized;
        rigid.AddForce(arah * force);
    }

    void ResetBall(bool arahKanan)
    {
        transform.localPosition = Vector2.zero;
        rigid.velocity = Vector2.zero;

        Vector2 arah = arahKanan ? new Vector2(1, 0) : new Vector2(-1, 0);
        rigid.AddForce(arah * force);

        menyentuhTepiKanan = false;
        menyentuhTepiKiri = false;
    }

    void UpdateScoreUI()
    {
        scoreKiriText.text = skorKiri.ToString();
        scoreKananText.text = skorKanan.ToString();
    }

    void CekGameSelesai()
    {
        if (skorKiri >= 5)
        {
            GameOver("Monyet Kiri Menang!");
        }
        else if (skorKanan >= 5)
        {
            GameOver("Monyet Kanan Menang!");
        }
    }

    void GameOver(string pemenang)
    {
        panelSelesai.SetActive(true);
        pemenangText.text = pemenang;
        gameObject.SetActive(false); // Hilangkan bola
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        string nama = coll.gameObject.name;

        // Putar suara jika tersedia
        if (hitSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        if (nama == "Tepi Kanan 1" || nama == "Tepi Kanan 2") menyentuhTepiKanan = true;
        if (nama == "Tepi Kiri 1" || nama == "Tepi Kiri 2") menyentuhTepiKiri = true;

        if (nama == "Tepi Kanan 3")
        {
            if (!menyentuhTepiKanan)
            {
                skorKiri++;
                Debug.Log("GOOOL Kiri! 🎉");
            }
            else
            {
                Debug.Log("Tidak sah, bola menyentuh tepi kanan.");
            }

            UpdateScoreUI();
            CekGameSelesai();
            ResetBall(false);
        }
        else if (nama == "Tepi Kiri 3")
        {
            if (!menyentuhTepiKiri)
            {
                skorKanan++;
                Debug.Log("GOOOL Kanan! 🎉");
            }
            else
            {
                Debug.Log("Tidak sah, bola menyentuh tepi kiri.");
            }

            UpdateScoreUI();
            CekGameSelesai();
            ResetBall(true);
        }
        else if (nama == "Monyet Kiri" || nama == "Monyet Kanan")
        {
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(arah * force);
        }
    }
}
