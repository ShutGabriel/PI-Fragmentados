using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDanoMapinguari : MonoBehaviour
{
    public bool DanoAplicado;
    GameControl gameControl;
   public  ScMapinguari ScMapinguari;

    // Start is called before the first frame update
    void Start()
    {
        gameControl= Camera.main.GetComponent<GameControl>();
        ScMapinguari = GameObject.Find("Mapinguari-Boss").GetComponent<ScMapinguari>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Moveplayer>())
            {
                collision.GetComponent<Moveplayer>().Dano(ScMapinguari.DanoAtaque1);
            }

            /*
            if (DanoAplicado == false)
            {
                gameControl.LifePlayer();
                   DanoAplicado = true;
            }*/

        }
    }
}
