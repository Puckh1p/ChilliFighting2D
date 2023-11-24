using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad;
    public float da�o;

    private void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            //GameObject.FindGameObjectWithTag("Bandera").GetComponent<Bandera>().EnemigoEliminado();
            other.GetComponent<Enemigo>().TomarDa�o(da�o);
            Destroy(gameObject);
        }
    }
}
