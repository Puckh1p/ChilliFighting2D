using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovimiento : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMovimiento;

    private Vector2 offset;

    private Material material;

    //private Rigibody2D jugadorRB;


    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        //jugadorRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigibody2D>();
    }

    private void Update()
    {
        offset = velocidadMovimiento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}

