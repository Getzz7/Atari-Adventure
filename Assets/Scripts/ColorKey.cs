using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class ColorKey : MonoBehaviour
{
    // Miembros de clase pública
    public Color colorObjeto;
    public int agarrada;

    // Miembros de clase protegidos
    protected Renderer render;

    // Método que se ejecuta cuando aparece este objeto en pantalla
    void Start()
    {
        PlayerPrefs.DeleteAll();
        render = GetComponent<Renderer>();
        agarrada = PlayerPrefs.GetInt(this.gameObject.name,0);
        Debug.Log("Nombre Objeto: " + this.gameObject.name);
        Debug.Log("Valor: " + agarrada);
        if(agarrada == 1)
        {
            Debug.Log("Llave agarrada");
            this.gameObject.SetActive(false);
        }
    }

    // Rutina que se ejecuta cada vez que se dibuja una nueva imagen en pantalla.
    void Update()
    {
        render.material.color = colorObjeto;
    }

    // Método que se ejecuta cuando este objeto interseca otro objeto en el juego.
    private void OnTriggerEnter(Collider other)
    {
        // Consultamos si el objeto que interseca tiene la etiqueta del jugador.
        if (other.CompareTag("Player")) 
        {
            PlayerData playerdata = other.gameObject.GetComponent<PlayerData>();
            playerdata.colorActual = IntercambiarColor(playerdata.colorActual);
            PlayerPrefs.SetInt(this.gameObject.name,1);
        }
    }

    // Método que reasigna colores.
    private Color IntercambiarColor(Color nuevoColor)
    {
        Color temporal = colorObjeto;
        colorObjeto = nuevoColor;
        return temporal;
    }
}
