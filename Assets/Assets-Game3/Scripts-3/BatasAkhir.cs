using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BatasAkhir : MonoBehaviour
{
    private bool bisaMengurangiNyawa = false;

    public AudioClip hitSound;
    private AudioSource audioSource;

    void Start()
    {
        Invoke("AktifkanPenguranganNyawa", 1f);
        audioSource = GetComponent<AudioSource>();
    }

    void AktifkanPenguranganNyawa()
    {
        bisaMengurangiNyawa = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!bisaMengurangiNyawa) return;

        if (collision.CompareTag("Karnivora") || collision.CompareTag("Herbivora"))
        {
            if (hitSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(hitSound);
            }

            Destroy(collision.gameObject);
            Data.nyawa--;

            Debug.Log("Nyawa sekarang: " + Data.nyawa);

            if (Data.nyawa <= 0)
            {
                StartCoroutine(TundaGameOver(1f)); 
            }
        }
    }

    IEnumerator TundaGameOver(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver");
    }
}
