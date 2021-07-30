using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouch : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
   {
       if(other.gameObject.tag == "Player")
       {
           // toque al jugador y el jugador perdio el juego
           
       }
   }
}
