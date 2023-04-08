using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorAsteriodes : MonoBehaviour
{
    public GameObject asteriodePrefab;
    public Transform[] generadorPuntos;
    public float velocidadGeneracion;
    
    void Start()
    {
        InvokeRepeating("generarAsteroide", velocidadGeneracion, 1f);
    }

    
    
    private void generarAsteroide() {
        Instantiate(asteriodePrefab, 
            generadorPuntos[Random.Range(0,generadorPuntos.Length)].position,
            Quaternion.identity);
    
    }

}
