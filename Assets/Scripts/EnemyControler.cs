using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControler : MonoBehaviour
{
    public float distanciaMinima;
    public float distanciaMaxima;
    private float distanciaActual; 
    public Transform Jugador; 
    public Transform PosicionInicial;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // el enemigo persigue al jugador
       distanciaActual = Vector3.Distance(Jugador.position, this.transform.position);
       Debug.Log(distanciaActual); 
       

       if(distanciaActual < distanciaMinima)
       {
           if( distanciaActual > distanciaMaxima)
           {
               agent.Stop();
           }
           else
           {
               agent.Resume();
               // La distancia actual es menor a la minima persigue al jugador
            agent.SetDestination(Jugador.position);
            transform.LookAt(Jugador.position);
           }   
       }
       else
       {
            distanciaActual = Vector3.Distance(PosicionInicial.position, this.transform.position);
           if(distanciaActual < distanciaMaxima)
           {
               agent.Stop();
           }
           else
           {
                agent.Resume();
                // No perseguir al jugar e ir a la posicion inicial
                agent.SetDestination(PosicionInicial.position);
                transform.LookAt(PosicionInicial.position);
           }
           
       }

       
    }
}
