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

    // Timer Variables
    private float gameTime = 120f; // 2 minutes in seconds
    public Text timerText; // Reference to UI Text element to display the timer

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>(); // Initialize AudioSource

        UpdateScoreUI();
        panelSelesai.SetActive(false); // Hide panel at the start
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

    // Update the timer display
    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
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
        else if (gameTime <= 0)
        {
            // Time's up, check score
            if (skorKiri > skorKanan)
            {
                GameOver("Monyet Kiri Menang!");
            }
            else if (skorKiri < skorKanan)
            {
                GameOver("Monyet Kanan Menang!");
            }
            else
            {
                GameOver("Seri!");
            }
        }
    }

    void GameOver(string pemenang)
    {
        panelSelesai.SetActive(true);
        pemenangText.text = pemenang;
        gameObject.SetActive(false); // Hide the ball
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        string nama = coll.gameObject.name;

        // Play sound if available
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
        else if (nama == "Monyet Kiri" || nama == "Monyet Kanan" || nama == "Tepi Atas" || nama == "Tepi Bawah")
        {
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(arah * force);
        }
    }

    void Update()
    {
        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;
            UpdateTimerDisplay();

            if (gameTime <= 0)
            {
                gameTime = 0; // pastikan tidak negatif
                CekGameSelesai(); // cek siapa pemenangnya segera setelah waktu habis
            }
        }
    }
}
