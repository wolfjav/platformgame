using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Movement : MonoBehaviour
{
    private float movx;
    public AudioClip musica;
    private AudioSource source;
    public float velx;
    public float vely;
    public Text vischrono;
    public Button next;
    public Button retry;
    public Button exit;
    private Rigidbody2D rigidb;
    public Vector3 posicioninicial;
    string level;
    float chrono;

    // Start is called before the first frame update
    void Start()
    {
        rigidb = GetComponent<Rigidbody2D>();
        next.onClick.AddListener(OnNextClick);
        next.gameObject.SetActive(false);
        retry.onClick.AddListener(OnRetryClick);
        retry.gameObject.SetActive(false);
        exit.onClick.AddListener(OnExitClick);
        exit.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        movx = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movx, 0, 0) * Time.deltaTime * velx;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        if(Input.GetButtonDown("Jump") && Mathf.Abs(rigidb.velocity.y)<0.001f)
        {
            rigidb.AddForce(new Vector2(0, vely), ForceMode2D.Impulse);
            
        }
        if(Input.GetKeyDown("q") || Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }
    void FixedUpdate()
    {
        chrono += 2;
        vischrono.text = Convert.ToString(chrono);        
    }
    private void OnTriggerEnter2D(Collider2D coli)
    {
        switch(coli.gameObject.tag)
        {
            case "lava":
                Die();
                break;
            case "puerta":
                next.gameObject.SetActive(true);
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D coli) 
    {
        switch(coli.gameObject.tag)
        {
            case "enemie":
                Die();
                break;
        }
    }
    void Die()
    {
        Destroy(gameObject);
        retry.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);
    }
    void OnNextClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void OnRetryClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void OnExitClick()
    {
        Application.Quit();
    }
}