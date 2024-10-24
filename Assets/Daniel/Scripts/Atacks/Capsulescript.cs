using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Capsulescript : MonoBehaviour
{


    public GameObject[] balas;
    public float lifetime;
    public float direction;

    // Start is called before the first frame update
    void Start()
    {
        setbulletdirection();
    }

    // Update is called once per frame
    void Update()
    {
        bulletdeath();
    }


    public void setbulletdirection()
    {
        for (int i = 0; i < balas.Length; i++)
        {
            balas[i].GetComponent<ShootAttack>().direcao = direction;
            balas[i].GetComponent<ShootAttack>().qualTiro = 1;
        }
    }

    public void bulletdeath()
    {
        lifetime-=Time.deltaTime;

        if (lifetime < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
