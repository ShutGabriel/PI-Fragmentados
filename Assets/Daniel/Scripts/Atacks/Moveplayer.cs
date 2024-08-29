using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Moveplayer : MonoBehaviour
{

    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Vector2 _move;
    [SerializeField] float _forceJump;
    public GameObject bala;
    public Transform bulletPoint;
    public Transform bulletPointCima;

    bool _facingRight;
    public bool _checkground;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
        _rb.velocity = new Vector2(_move.x * _speed, _rb.velocity.y);



        if (_move.x > 0 && _facingRight == true)
        {
            flip();
        }
        else if (_move.x < 0 && _facingRight == false)
        {
            flip();
        }

        


    }





   public void SetMove(InputAction.CallbackContext value)
    {


        _move = value.ReadValue<Vector2>();




    }

    void flip()
    {
        _facingRight = !_facingRight;
        float x = transform.localScale.x;
        x *= -1;

        transform.localScale = new Vector2(x, transform.localScale.y);


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("ground"))
        {

            Debug.Log("touched the ground");

            _checkground = true;

        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("ground"))
        {

            Debug.Log("left the ground");

            _checkground = false;
        }



    }


    public void SetJump(InputAction.CallbackContext value)
    {


        if (_checkground == true)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 0);
            _rb.AddForce(Vector2.up * _forceJump, ForceMode2D.Impulse);
          


        }

    }


    public void shoot()
    {

        
        
        Instantiate(bala, bulletPoint.position, bala.transform.rotation);






    }



}


