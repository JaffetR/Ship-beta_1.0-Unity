using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NaveControl : MonoBehaviour
{
    public float velocidad = 1;
    Rigidbody2D rb;
    //disparar bala
    public GameObject balaPrefab;
    public Transform posicionLanzarBala;
    public GameObject balaPrefab2;
    public Transform posicionLanzarBala2;

    public GameManager manager;
    public AudioSource audioSource;

    public AudioClip audioClipExplosion;
    public AudioClip audioClipChoque;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
       
    void FixedUpdate()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + 
            new Vector2(movHorizontal, movVertical)*velocidad*Time.deltaTime);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dispararBala();
            audioSource.Play();
            dispararBala2();
        }
    }

    private void dispararBala()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // mediante el paso valor de interface
            // en el script navecontrol se asocie prefabbala y posicionlanzar bala
            Instantiate(balaPrefab, posicionLanzarBala.position, Quaternion.identity);
        }
    }

    private void dispararBala2()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // mediante el paso valor de interface
            // en el script navecontrol se asocie prefabbala y posicionlanzar bala
            Instantiate(balaPrefab2, posicionLanzarBala2.position, Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroide")
        {
            Destroy(collision.gameObject);
            manager.numeroVidas--;
            // esto sucede cuando choque -> sonido
            AudioSource.PlayClipAtPoint(audioClipChoque, 
                gameObject.transform.position);
            if (manager.numeroVidas<=0)
            {
                AudioSource.PlayClipAtPoint(audioClipExplosion,
                    gameObject.transform.position);
            }
        }

    }

}

