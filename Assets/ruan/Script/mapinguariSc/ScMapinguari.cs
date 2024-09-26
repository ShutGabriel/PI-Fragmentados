using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScMapinguari : MonoBehaviour
{
    public Animator _animator;

    [Header("controle Layer")]
    public bool trocarLayer;
    public SpriteRenderer[] partesCorpo;
    public int[] posiLayerFrete;
    public int[] posiLayerTras;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ControleSprite();
    }

    public void ControleSprite()
    {
        if (trocarLayer == false)
        {
            for (int i = 0; i < partesCorpo.Length; i++) 
            {
                partesCorpo[i].sortingOrder = posiLayerFrete[i];                    
            }
        }
        else
        {
            for (int i = 0; i < partesCorpo.Length; i++)
            {
                partesCorpo[i].sortingOrder = posiLayerTras[i];
            }
        }

       

    }
}
