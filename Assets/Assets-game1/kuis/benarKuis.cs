using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class benarKuis : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Transform Jawaban;
    private Vector2 initialPosition;
    private float deltaX, deltaY;
    public static bool locked;
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!locked)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos))
                {
                    deltaX = mousePos.x - transform.position.x;
                    deltaY = mousePos.y - transform.position.y;
                }
            }

            if (Input.GetMouseButton(0))
            {
                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos))
                {
                    transform.position = new Vector2(mousePos.x - deltaX, mousePos.y - deltaY);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (Mathf.Abs(transform.position.x - Jawaban.position.x) <= 0.5f &&
                    Mathf.Abs(transform.position.y - Jawaban.position.y) <= 0.5f)
                {
                    transform.position = new Vector2(Jawaban.position.x, Jawaban.position.y);
                    locked = true;
                }
                else
                {
                    transform.position = new Vector2(initialPosition.x, initialPosition.y);
                }
            }
        }
    }
}
