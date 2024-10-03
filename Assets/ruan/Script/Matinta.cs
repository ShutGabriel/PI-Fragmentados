using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matinta : MonoBehaviour
{
    public int quantAtaque1;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        controleAtaques();
    }

    public void controleAtaques()
    {
        if (quantAtaque1 >= 10)
        {
            animator.SetBool("rasante", true);
        }      

    }


    public void ataque1Es()
    {
        print("ataque");
        addquantAtaque1();
    }

    public void addquantAtaque1()
    {
        quantAtaque1++;
    }

    public void finalRasnte()
    {
        animator.SetBool("rasante", false);
        quantAtaque1 = 0;

    }
}
