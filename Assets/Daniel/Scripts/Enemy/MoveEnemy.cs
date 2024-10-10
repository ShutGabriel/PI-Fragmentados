using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveEnemy : MonoBehaviour
{


    Rigidbody2D _rigb;
    [SerializeField] float _speed;
    public Transform _direcao;
    public Transform[] _pos;
    public Transform _player;
    public float _displayer;
    public float _distanseguir;
    public bool _checkloop;
    // Start is called before the first frame update
    void Start()
    {
        

        _rigb = GetComponent<Rigidbody2D>();
        _direcao = _pos[0];

    }

    // Update is called once per frame
    void fixedUpdate()
    {

        _displayer = Vector2.Distance(transform.position, _player.position);
        if (_displayer <= _distanseguir )
        {



            _direcao = _player;

            _checkloop = true;




        }
        else if (_checkloop==true)
        {
            _checkloop = false;
            _direcao = _pos[1];

        }

        Vector2 direcao = (_direcao.position - transform.position).normalized;


     

        _rigb.MovePosition(_rigb.position + direcao * _speed * Time.deltaTime);


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "pos1")
        {


            Debug.Log("pos1");
            _direcao = _pos[0];

        }
        else if (collision.gameObject.name == "pos2")
        {


            Debug.Log("pos2");
            _direcao = _pos[1];


        }



    }
}
