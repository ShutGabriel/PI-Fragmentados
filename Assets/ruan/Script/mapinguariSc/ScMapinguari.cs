using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScMapinguari : MonoBehaviour
{

    [Header("controle Layer")]
    public bool trocarLayer;
    public SpriteRenderer[] partesCorpo;
    public SpriteRenderer[] Boca;
    public int[] posiLayerFrete;
    public int[] posiLayerTras;

    [Header("controleAnimaçoes")]
    public Animator _animator;
    public bool trocarPosi;
    public bool introJaExecutada;
    public bool PosiJaSet;
    public float[] posiArvore;
    public float UltimaPosiX;

    [Header("controle de ataque")]
    public float NextAtqTime;
    public float TempoMaxAtq;
    public int qualAtaque;
    public int quantAtaques;

    [Header("controleStatus")]
    public int hpMax;
    public int Hp;

    [Header("controle de componentes")]
    public Rigidbody2D rb;
    public BoxCollider2D[] boxCollider;

    [Header("controleAtaque1")]
    public float jumpPower;
    public bool pulando;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Hp = hpMax;

    }

    // Update is called once per frame
    void Update()
    {
        ControleSprite();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            trocarPosi = !trocarPosi;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            AtivarAnimaAtaque1();
        }

    }

    public void ControleSprite()
    {
        _animator.SetBool("trocarPosi", trocarPosi);
        _animator.SetBool("Chao",pulando);

        if (trocarLayer == false)
        {
            for (int i = 0; i < partesCorpo.Length; i++) 
            {
                partesCorpo[i].sortingOrder = posiLayerFrete[i];                    
            }

            for (int i = 0; i < Boca.Length; i++)
            {
                Boca[i].sortingOrder = posiLayerFrete[6];
            }

            if (transform.position.x > 0)
            {
                if (PosiJaSet == true)
                {
                    UltimaPosiX = transform.position.x;
                    transform.position = new Vector2(UltimaPosiX, transform.position.y);
                    PosiJaSet = false;
                }
            }

            rb.gravityScale = 2.0f;
            for (int i = 0;i < boxCollider.Length; i++)
            {
                boxCollider[i].enabled = true;
            }



        }
        else
        {
            for (int i = 0; i < partesCorpo.Length; i++)
            {
                partesCorpo[i].sortingOrder = posiLayerTras[i];
            }

            for (int i = 0; i < Boca.Length; i++)
            {
                Boca[i].sortingOrder = posiLayerTras[6];
            }

            if (transform.position.x > 0)
            {
                if (PosiJaSet == false)
                {
                    UltimaPosiX = transform.position.x;
                    transform.position = new Vector2(posiArvore[0],transform.position.y);
                    transform.localScale = new Vector3(0.4f, 0.4f, 0);
                    PosiJaSet = true;
                }
            }
            else
            {
                if (PosiJaSet == false)
                {
                    UltimaPosiX = transform.position.x;
                    transform.position = new Vector2(posiArvore[1], transform.position.y);
                    transform.localScale = new Vector3(-0.4f, 0.4f,0);
                    PosiJaSet = true;
                   
                }

            }
            rb.gravityScale = 0f;
            for (int i = 0; i < boxCollider.Length; i++)
            {
                boxCollider[i].enabled = false;
            }

        }



    }

    public void controlesAtaque()
    {
        if (introJaExecutada == true)
        {
            NextAtqTime -= Time.deltaTime;

            if (NextAtqTime <= 0)
            {
                if (Hp > hpMax / 2)
                {
                    qualAtaque = Random.Range(0,2);
                    quantAtaques = Random.Range(2, 4);
                }
                else
                {
                    qualAtaque = 0;
                    quantAtaques = Random.Range(2, 4);

                }
            }

        }

    }

    public void AtivarAnimaAtaque1()
    {
        _animator.SetTrigger("ataque");
    }

    public void ataqueUm()
    {
        if (qualAtaque == 0)
        {
            if (pulando == false)
            {
                Vector2 jumpVelocity = new Vector2(0, jumpPower);
                Vector2 jumpFrent = new Vector2( -jumpPower/2,0);               
                rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

                if (transform.localScale.x > 0)
                {
                    rb.AddForce(jumpFrent, ForceMode2D.Impulse);
                }
                else
                {
                    rb.AddForce(-jumpFrent, ForceMode2D.Impulse);
                }

                pulando = true;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            pulando = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bloqueio")
        {
            Vector2 jumpVelocity = new Vector2(0, jumpPower/1.5f);
            Vector2 jumpFrent = new Vector2(-jumpPower / 2.5f, 0);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            if (transform.localScale.x > 0)
            {
                rb.AddForce(-jumpFrent, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(jumpFrent, ForceMode2D.Impulse);
            }
            transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);

        }
    }
}
