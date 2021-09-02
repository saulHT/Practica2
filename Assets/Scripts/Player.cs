using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    public float jumpForce = 40;
    int contador;
    int contador1;
    float velocidad_inicial=1.5f;
    private const int animation_correr = 0;
    private const int animation_saltar = 1;
    private const int animation_deslizar = 2;
    private const int animation_quieto = 3;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (contador>0  )
        {
            rb.velocity = new Vector2(velocidad_inicial *contador, rb.velocity.y);
            changeAnimation(animation_correr);
            Debug.Log("contar salto destruir" + contador);
        }
        else if (contador1 > 0)
        {
            rb.velocity = new Vector2(velocidad_inicial*contador1, rb.velocity.y);
            changeAnimation(animation_correr);
            Debug.Log("contar salto "+contador1);
        }
        
        
            rb.velocity = new Vector2(velocidad_inicial, rb.velocity.y);
            changeAnimation(animation_correr);
        

        if (contador1 ==10)
        {
            changeAnimation(animation_quieto);
        }
        if (contador == 10)
        {
            changeAnimation(animation_quieto);
        }

        if (Input.GetKey(KeyCode.M))
        {
            changeAnimation(animation_deslizar);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            changeAnimation(animation_saltar);
            contador1++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="enemigo" )
        {
           
                Destroy(collision.gameObject);
            contador++;
           
        }
    }
    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }

    
}
