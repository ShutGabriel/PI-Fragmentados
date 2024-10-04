using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaCamadaM : MonoBehaviour
{
    public ScMapinguari ScMapinguari;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void trocarLayerImagens()
    {
        ScMapinguari.trocarLayer = !ScMapinguari.trocarLayer;
    }

    public void ataque1()
    {
        ScMapinguari.ataqueUm();
    }

    public void introTerminada()
    {
        ScMapinguari.introJaExecutada = true;
    }

    public void finalAtaques()
    {
        ScMapinguari.finalAtaque();
    }
}
