using UnityEngine;
using System.Collections;
using System.Collections.Generic;
// Declaración de la clase
public class Sound_Handler : MonoBehaviour 
{
    public static Sound_Handler Instance;
    public AudioSource speaker1;
    public AudioSource speaker2;
    public AudioSource speaker3;

// Arreglo de archivos de audio
public AudioClip[] sounds;
// Inicialización del objeto singleton
void Awake () 
{
    if(Instance != null && Instance != this) 
    {
        Destroy(this.gameObject);
    }
    else 
    {
        Instance = this;DontDestroyOnLoad(this.gameObject);
    }
}
// Método público para reproducir sonido
public void playsound(int indexOfSound) 
{
    if(!speaker1.isPlaying) 
    {
        speaker1.PlayOneShot(sounds[indexOfSound]);
        }

    else if(!speaker2.isPlaying) 
    {
        speaker2.PlayOneShot(sounds[indexOfSound]);
     }
        else if(!speaker3.isPlaying) 
        {
            speaker3.PlayOneShot(sounds[indexOfSound]);
        }
    }
}