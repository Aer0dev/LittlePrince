using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor_Sh : MonoBehaviour
{
    public AudioSource audioSource;
    public Vector3 screenPosition;
    public Vector3 worldPosition;

    public SpriteRenderer cursor;

    public GameObject HitEffectPrefab;
    public float hitEffectDuration = 0.5f; // 히트 이펙트의 지속 시간

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
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Note")
        {
            show_effect(other);
            audioSource.Play();
        }
    }
    void show_effect(Collision col)
    {
        ContactPoint contact = col.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, contact.normal);

        GameObject hitEffect = Instantiate(HitEffectPrefab, contact.point, Quaternion.identity);
        Destroy(hitEffect, hitEffectDuration);
    }
    
}
