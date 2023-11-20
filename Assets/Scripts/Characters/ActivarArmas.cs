using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarArmas : MonoBehaviour
{
    public RecogerArmas recogerArmas;
    public int numeroArma;
    void Start()
    {
        recogerArmas = GameObject.FindGameObjectWithTag("Player").GetComponent<RecogerArmas>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            recogerArmas.ActivarArmas(numeroArma);
            Destroy(gameObject);
        }
    }
}
