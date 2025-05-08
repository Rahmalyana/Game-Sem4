using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

   [SerializeField] private GameObject winText;
    [SerializeField] private SoalManager soalManager;
    

    private bool winDisplayed = false;

    void Start()
    {
        winText.SetActive(false);
    }

    void Update()
    {
        // Tampilkan winText hanya sekali dan hanya jika sudah di soal terakhir
        if (benarKuis.locked && soalManager.nomorSoal == soalManager.totalSoal && !winDisplayed)
        {
            winText.SetActive(true);
            winDisplayed = true;
        }
    }
}
