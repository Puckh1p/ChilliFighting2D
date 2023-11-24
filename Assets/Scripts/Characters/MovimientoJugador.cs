using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;

    [SerializeField] public float velocidadDeMovimiento;
    [Range(0, 0.3f)] [SerializeField] private float suavizadoDeMovimiento;

    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;
    private bool salto = false;

    private Animator animator;

    private float inputX;

    [SerializeField] private Transform controladorPared;
    [SerializeField] private Vector3 dimensionesCajaPared;
    [SerializeField] private float velocidadDeslizar;
    private bool enPared;
    private bool deslizando;

    [SerializeField] private float fuerzaSaltoX;
    [SerializeField] private float fuerzaSaltoY;
    [SerializeField] private float tiempoSaltoPared;
    private bool saltandoDePared;



    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        movimientoHorizontal = inputX * velocidadDeMovimiento;
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));
        animator.SetFloat("VelocidadY", rb2D.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }

        if(!enSuelo && enPared && inputX != 0)
        {
            deslizando = true;
        }
        else
        {
            deslizando = false; 
        }
    }
    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        animator.SetBool("enSuelo", enSuelo);
        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);
        enPared = Physics2D.OverlapBox(controladorPared.position, dimensionesCajaPared, 0f, queEsSuelo);

        salto = false;

        if (deslizando)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, Mathf.Clamp(rb2D.velocity.y, -velocidadDeslizar, float.MaxValue));
        }
    }

    private void Mover(float mover, bool saltar)
    {
        if (!saltandoDePared)
        {
            Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
            rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);
        }

        if(mover > 0 && !mirandoDerecha)
        {
            Girar();
        }

        else if(mover < 0 && mirandoDerecha)
        {
            Girar();
        }

        if(saltar && enSuelo && !deslizando)
        {
            Salto();
        }

        if (saltar && enPared && deslizando)
        {
            SaltoPared();
        }
    }

    private void SaltoPared()
    {
        enPared = false;
        rb2D.velocity = new Vector2(fuerzaSaltoX * -inputX, fuerzaSaltoY);
        StartCoroutine(CambioSaltoPared());
    }

    IEnumerator CambioSaltoPared()
    {
        saltandoDePared = true;
        yield return new WaitForSeconds(tiempoSaltoPared);
        saltandoDePared = false;
    }

    private void Salto()
    {
        enSuelo = false;
        rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
        Gizmos.DrawWireCube(controladorPared.position, dimensionesCajaPared);
    }
}
