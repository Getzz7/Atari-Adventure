using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    // Miembros de clase pública
    public float velocidadDesplamiento = 5;
    public float velocidadSalto = 5;
    public float distanciaRayo = 1.1f;
    public bool enElPiso;
    public Animator anim;

    // Miembros de clase protegidos
    protected Rigidbody cuerpoRigido;
    protected float velocidadX;
    protected float velocidadY;
    protected float velocidadZ;
    protected RaycastHit hit;

    // Método que se ejecuta cuando aparece este objeto en pantalla
    void Start()
    {
        // Se obtiene la referencia al componente
        cuerpoRigido = GetComponent<Rigidbody>();
    }

    // Rutina que se ejecuta cada vez que se dibuja una nueva imagen en pantalla.
    void Update()
    {
        // Lectura de teclado
        velocidadX = Input.GetAxisRaw("Horizontal") * velocidadDesplamiento;
        velocidadZ = Input.GetAxisRaw("Vertical") * velocidadDesplamiento;
        if (velocidadX + velocidadZ == 0)
        {
            if(anim != null) 
            {
            anim.SetFloat("speed",0f);
            }
        }
            
        else
        {
           if(anim != null) anim.SetFloat("speed",Mathf.Abs(velocidadX) + Mathf.Abs(velocidadZ));
        }
        // Tecla de salto
        if (enElPiso && Input.GetKeyDown(KeyCode.Space))
        {
            velocidadY = velocidadSalto;
        }
        else
        {
            velocidadY = cuerpoRigido.velocity.y;
        }

        // Se aplica la velocidad
        cuerpoRigido.velocity = new Vector3(velocidadX, velocidadY, velocidadZ);
    }

    // rutina que se ejecuta después de que todos los calculos físicos han sido completados.
    private void FixedUpdate()
    {
        TocaPiso();
    }

    // Metodo privado que 
    private void TocaPiso()
    {
        // Se dibuja una linea para poder visualizarla en el Unity Editor.
        Debug.DrawLine(
            this.transform.position, 
            this.transform.position + (Vector3.down * distanciaRayo),
            Color.white);

        // Lanzamos un rayo, si este impacta alguna superficie, el valor de "enElPiso" será verdadero
        // de lo contrario será falso.
        enElPiso = Physics.Raycast(transform.position, Vector3.down, distanciaRayo);
    }
}