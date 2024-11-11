using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TrocaCamadaM : MonoBehaviour
{
    public ScMapinguari ScMapinguari;
    public efeitoCamera efeitoCamera;


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

    public void AtivarAreaAtaque()
    {
        ScMapinguari.areaAtaque.SetActive(true);
    }

    public void finalDano()
    {
        ScMapinguari._animaDano.SetBool("Dano",false);
    }

    public void ativarGrito()
    {
        ScMapinguari.mpSom.ativarSom(0);
    }

    public void somPulo()
    {
        ScMapinguari.mpSom.ativarSom(1);

    }

    public void SomimpactoChao()
    {
        ScMapinguari.mpSom.ativarSom(2);
        efeitoCamera.TremerTela();


    }
}
