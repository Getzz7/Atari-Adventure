using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BorrarJuego()
    {
        PlayerPrefs.DeleteAll();
    }

    public void CambioEscena(string nombreEscena)
    {
        Debug.Log("Hola, has hecho click en este boton");
        SceneManager.LoadScene(nombreEscena);
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
