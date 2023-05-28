using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor_Sh : MonoBehaviour
{
    public AudioSource audioSource;
    public Vector3 screenPosition;
    public Vector3 worldPosition;

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
        screenPosition = Input.mousePosition;
        screenPosition.z = Camera.main.nearClipPlane +9.7f;
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
      
        transform.position = worldPosition;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Note")
        {
            audioSource.Play();
        }
    }
}
