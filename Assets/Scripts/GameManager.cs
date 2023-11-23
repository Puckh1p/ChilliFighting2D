using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public HUD hud;
    private int vidas = 3;
    public GameObject canvasPerder;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas de un GameManager en escena");
        }
    }

    public void PerderVidas()
    {
        vidas -= 1;
        if(vidas == 0)
        {
            //SceneManager.LoadScene(0);
            canvasPerder.SetActive(true);
            Time.timeScale = 0f;
        }
        hud.DesactivarVida(vidas);
    }

    public bool RecuperarVida()
    {
        if(vidas == 3)
        {
            return false;
        }
        hud.ActivarVida(vidas);
        vidas += 3 ;
        return true;
    }
}
