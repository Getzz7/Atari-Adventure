using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDoor : MonoBehaviour
{
    // Miembros de clase pública
    public GameObject puerta;

    public Color colorRequerido;
    public float distanciaMover = 3f;
    public int abierta;
    // Miembros de clase protegidos
    protected Renderer puertaRender;
    protected bool abierto;

    // Método que se ejecuta cuando aparece este objeto en pantalla
    void Start()
    {
        puertaRender = puerta.GetComponent<Renderer>();
        puertaRender.material.color = colorRequerido;
        abierta = PlayerPrefs.GetInt(this.gameObject.name,0);
        if(abierta==1)
        {
            //La puerta ya fue abierta ,proceder a abirila si esta cerrada
            Debug.Log("El color coincide");
            puerta.transform.Translate(Vector3.down * distanciaMover);
            abierto = true;
        }
    }

    // Método que se ejecuta cuando este objeto interseca otro objeto en el juego.
    private void OnTriggerEnter(Collider other)
    {
        // Consultamos si el objeto que interseca tiene la etiqueta del jugador.
        if (!abierto && other.CompareTag("Player"))
        {
            Debug.Log("Jugador Detectado");
            PlayerData playerdata = other.gameObject.GetComponent<PlayerData>();

            if(playerdata.colorActual == colorRequerido) 
            {
                Debug.Log("El color coincide");
                puerta.transform.Translate(Vector3.down * distanciaMover);
                abierto = true;
                PlayerPrefs.SetInt(this.gameObject.name,1);
            }
            else
            {
                Debug.Log("El jugador tiene el color " + playerdata.colorActual.ToString() );
                Debug.Log("La puerta tiene el color " + colorRequerido.ToString() );
            }
        }
    }
}   
