using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class desativarSom : MonoBehaviour
{
    public AudioSource audioAs;

    void Start()
    {
        audioAs.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        desativar();
    }

    public void desativar()
    {
        if (!audioAs.isPlaying)
        {
            this.gameObject.SetActive(false);
        }
    }
}
