using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouch : MonoBehaviour

{
    public string SiguienteEscena;
    public TypeOfSound sonido = TypeOfSound.Door;
   void OnTriggerEnter(Collider other)
   {
       if(other.gameObject.tag == "Player")
       {
           // toque al jugador y el jugador perdio el juego
           Sound_Handler.Instance.playsound((int)sonido);
           GameManager.instance.ChangeScenes(SiguienteEscena);
       }
   }
}
