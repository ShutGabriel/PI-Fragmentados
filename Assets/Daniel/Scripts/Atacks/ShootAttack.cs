using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttack : MonoBehaviour
{

    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float timetodie;
    control Player;
    public Animator animator;
    public bool shootanim;
    public bool timerativado;


    // Start is called before the first frame update
    void Start()
    {
        Player = Camera.main.GetComponent<control>();
        speedactivate();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerativado==true)
        {
            Invoke("desativarbala",5);
            timerativado = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Inimigo"))
        { 
            if (collision.gameObject.GetComponent<ScMapinguari>())
            {
                collision.gameObject.GetComponent<ScMapinguari>().Dano();
                desativarbala();
            }
        }

    }

    public void desativarbala()
    {
        gameObject.SetActive(false);
    }

    public void speedactivate()
    {
        if (Player._player.transform.localScale.x > 0)
        {
            _rb.velocity = new Vector2(_speed, 0);
        }
        else
        {
            _rb.velocity = new Vector2(-_speed, 0);
        }
    }

}


