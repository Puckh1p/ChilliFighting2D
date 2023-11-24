using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{

    [SerializeField] private GameObject loseMenu;

   public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
