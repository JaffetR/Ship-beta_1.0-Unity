using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public enum EstadosdelJuego {PREPARADO, JUGANDO, GAMEOVER}
    public EstadosdelJuego estado;

    public int numeroVidas = 3;
    public GameObject player;
    public GameObject generadorAsteroides;
    public Text mensajesTXT;

    void Start()
    {
        estado = EstadosdelJuego.PREPARADO;
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (estado)
        {
            case EstadosdelJuego.PREPARADO:
                mensajesTXT.text = "Presione la tecla espaciadora para iniciar";
                player.SetActive(false);
                generadorAsteroides.SetActive(false);

                if (Input.GetKeyDown(KeyCode.Space))
                    {
                    player.SetActive(true);
                    generadorAsteroides.SetActive(true);
                    estado = EstadosdelJuego.JUGANDO;
                }
                break;
            
            case EstadosdelJuego.JUGANDO:
                mensajesTXT.text = "Vidas: " + numeroVidas;
                if (numeroVidas<=0)
                {
                    player.SetActive(false);
                    estado = EstadosdelJuego.JUGANDO;
                }
                break;

            case EstadosdelJuego.GAMEOVER:
                mensajesTXT.text = "GameOver Presione espaciadora para iniciar el juego";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene(0);
                }
                break;
                default: break;


        }
        
    }
}
