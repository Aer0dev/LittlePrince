using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor_Sh : MonoBehaviour
{
    public SpriteRenderer cursor;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible= false;
        cursor = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }
}
