using System.Collections;
using System.Collections.Generic;
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
                Vector2 jumpFrent = new Vector2(-jumpPower/2,0);
                rb.AddForce(jumpVelocity, ForceMode2D.Impulse);
                rb.AddForce(jumpFrent, ForceMode2D.Impulse);

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
}
