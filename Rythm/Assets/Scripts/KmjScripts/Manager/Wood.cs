using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public float woodSpeed;

    UnityEngine.UI.Image woodImage;

    private void Start()
    {
        woodImage = GetComponent<UnityEngine.UI.Image>();
    }

    void Update()
    {
        transform.localPosition += Vector3.right * woodSpeed * Time.deltaTime;
        if(this.transform.position.x>2200)
        {
            Destroy(this.gameObject);
        }
    }
}
