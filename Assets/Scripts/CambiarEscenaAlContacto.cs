using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CambiarEscenaAlContacto : MonoBehaviour
{
    public int numeroPuerta;
    public int puertaDestino;
    public string SiguienteEscena;
    public Transform PosicionRespawn;
    public Player ObjetoJugador;
    public TypeOfSound sonido = TypeOfSound.Door;
    
    private void OnTriggerEnter(Collider other)
 {
    if (other.CompareTag("Player"))
 {
    // Aqui va el codigo para guardar el sonido
    Sound_Handler.Instance.playsound((int)sonido);
    //Aqui va el codigo para guardar la puerta de Destino
    GameManager.instance.SetDoor(puertaDestino.ToString());
    GameManager.instance.ChangeScenes(SiguienteEscena);
 }
 }

   void Start()
   {
      if(GameManager.instance.GetDoor()==numeroPuerta.ToString())
      {
        ObjetoJugador.transform.position=PosicionRespawn.position; 
      }
   }
} 