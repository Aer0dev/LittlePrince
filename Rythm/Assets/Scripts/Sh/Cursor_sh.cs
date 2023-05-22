using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cursor_sh : MonoBehaviour
{
    public SpriteRenderer rend;
    void Start()
    {
        Cursor.visible = false;
        rend.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }
}
