using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bandera : MonoBehaviour
{
    [SerializeField] private int cantidadEnemigos;
    [SerializeField] private int enemigosEliminados;
    [SerializeField] private GameObject winCondition;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        cantidadEnemigos = GameObject.FindGameObjectsWithTag("Enemigo").Length;
    }

    private void ActivarBandera()
    {
        animator.SetTrigger("Activar");
    }

    public void EnemigoEliminado()
    {
        enemigosEliminados += 1;
        if(enemigosEliminados == cantidadEnemigos)
        {
            ActivarBandera();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && enemigosEliminados == cantidadEnemigos)
        {
            Time.timeScale = 0f;
            winCondition.gameObject.SetActive(true);
        }
    }

}
