using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    private float speed;
    // Start is called before the first frame update
    public void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        speed = Random.Range(0.1f, 0.15f);


    }

    // Update is called once per frame
    public void Update()
    {
        this.transform.Translate(-speed, 0, 0);
        if (this.transform.localPosition.x < -10)
        {
            Destroy(this.gameObject);
        }
        

    }
}