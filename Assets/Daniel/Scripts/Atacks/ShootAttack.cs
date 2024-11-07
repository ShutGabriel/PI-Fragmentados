using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttack : MonoBehaviour
{

    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float timetodie;
    public Moveplayer scPlayer;
    public control Player;
    public Animator animator;
    public bool shootanim;
    public bool timerativado;
    public float direcao;
    public int qualTiro;
    public GameObject Hit;
    public GameObject som;

    // Start is called before the first frame update
    void Start()
    {
        Player = Camera.main.GetComponent<control>();
       // speedactivate();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerativado == false)
        {
            Invoke("desativarbala",3);
            timerativado = true;
        }
        if (direcao > 0)
        {
            _rb.transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
        else
        {
            _rb.transform.Translate(-_speed * Time.deltaTime, 0, 0);
        }

    }
    public void SpawnHit()
    {
        Instantiate(Hit, transform.position, transform.rotation);
        Instantiate(som, transform.position, transform.rotation);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Inimigo"))
        {
            if (qualTiro == 0)
            {
                if (collision.gameObject.GetComponent<ScMapinguari>())
                {
                    if (scPlayer.liberaTiro == false)
                    {
                        scPlayer.energia++;
                    }
                    collision.gameObject.GetComponent<ScMapinguari>().Dano();
                    desativarbala();
                }
            }
            else
            {
                if (collision.gameObject.GetComponent<ScMapinguari>())
                {
                    collision.gameObject.GetComponent<ScMapinguari>().Dano();
                    desativarbala();
                }
            }
        }

    }

    public void desativarbala()
    {
        SpawnHit();
        Destroy(this.gameObject);
        //gameObject.SetActive(false);
    }

    public void speedactivate()
    {
        Player = Camera.main.GetComponent<control>();
        if (Player._player.transform.localScale.x > 0)
        {
            //_rb.velocity = Vector2.right * _speed * Time.deltaTime;
            _rb.transform.Translate(_speed * Time.deltaTime,0,0);
        }
        else
        {
            // _rb.velocity = -Vector2.right * _speed * Time.deltaTime;
            _rb.transform.Translate(-_speed * Time.deltaTime, 0, 0);

        }
    }

}


