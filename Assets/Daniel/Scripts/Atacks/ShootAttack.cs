using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttack : MonoBehaviour
{

    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float timetodie;
    control Player;



    // Start is called before the first frame update
    void Start()
    {

        Player = Camera.main.GetComponent<control>();
 



    }

    // Update is called once per frame
    void Update()
    {

        if (Player._player.transform.localScale.x > 0)
        {
            _rb.velocity = new Vector2(_speed, 0);
        }
        else
        {
            _rb.velocity = new Vector2(-_speed, 0);
        }
       

        timetodie += Time.deltaTime;

        if (timetodie > 3) 
        {

            Destroy(this.gameObject);


        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag(""))
        { 
        
            Destroy(this.gameObject);
            
        
        }


    }


}


