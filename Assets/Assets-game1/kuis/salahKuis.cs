using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salahKuis : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 initialPosition;
    private float deltaX, deltaY;
    private bool isDragging = false;
    void Start()
    {
         initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos))
            {
                deltaX = mousePos.x - transform.position.x;
                deltaY = mousePos.y - transform.position.y;
                isDragging = true;
            }
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            transform.position = new Vector2(mousePos.x - deltaX, mousePos.y - deltaY);
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            transform.position = initialPosition;
            isDragging = false;
        }
    }
}
