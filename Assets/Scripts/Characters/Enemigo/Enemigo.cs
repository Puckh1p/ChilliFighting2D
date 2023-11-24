using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private GameObject efectoMuerte;

    public void TomarDaño(float daño)
    {
        vida -= daño;
        if(vida <= 0)
        {
            Muerte();
        }
    }
    private void Muerte()
    {
        GameObject.FindGameObjectWithTag("Bandera").GetComponent<Bandera>().EnemigoEliminado();
        Instantiate(efectoMuerte, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
