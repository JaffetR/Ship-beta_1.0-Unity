using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovAsteroide : MonoBehaviour
{
    public float tamMinimo=1f;
    public float tamMaximo=15f;
    public float vel_minimaRotacion=30f;
    public float vel_maximaRotacion=100f;
    public float velocidadRotacion;
    public float escala_minGravedad=0.1f;
    public float escala_maxGravedad=0.8f;
    private Rigidbody2D rb;

    
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        generaAleatorios();
        Destroy(this.gameObject, 7f);

    }

    
    void Update()
    {
        this.transform.Rotate(0,0,velocidadRotacion*Time.deltaTime);
    }
    private void generaAleatorios() {
        float randomEscala = Random.Range(tamMinimo, tamMaximo);
        this.transform.localScale = new Vector3(randomEscala,randomEscala,randomEscala);
        velocidadRotacion = Random.Range(vel_minimaRotacion, vel_maximaRotacion);
        rb.gravityScale = Random.Range(escala_minGravedad, escala_maxGravedad);

    
    }

}
