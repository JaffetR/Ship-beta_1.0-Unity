using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 3f;

    void Start()
    {
        Destroy(gameObject, 5f);
    }


    void Update()
    {
        // += -> acumula
        transform.position += Vector3.up * velocidad * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D otroGameObject)
    {
        
        // otro game object es asteoride
        if (otroGameObject.gameObject.tag=="Asteroide")
        {
            // destruye el asteoriede
            Destroy(otroGameObject.gameObject);

            // destruye la bala
            Destroy(this.gameObject);
        }
    }
    
}
