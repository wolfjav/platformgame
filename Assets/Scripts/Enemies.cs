using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private float emovx;
    public float evelx;
    public GameObject prota;
    public Vector3 pposicioninicial;
    public Vector3 eposicioninicial;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = eposicioninicial;
        emovx = -1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(emovx, 0, 0) * Time.deltaTime * evelx;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        if(prota.transform.position.x == pposicioninicial.x)
            transform.position = eposicioninicial;
    }
    private void OnCollisionEnter2D(Collision2D coli) 
    {
        switch(coli.gameObject.tag)
        {
            case "edge":
                emovx = 0 - emovx;
                transform.position += new Vector3(emovx, 0, 0) * Time.deltaTime * evelx;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D coli)
    {
        switch(coli.gameObject.tag)
        {
            case "lava":
                transform.position = eposicioninicial;
                emovx = -1;
                break;
        }
    }
}
