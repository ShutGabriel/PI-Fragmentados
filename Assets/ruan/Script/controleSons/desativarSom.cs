using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class desativarSom : MonoBehaviour
{
    public AudioSource audioAs;

    public bool destruir;
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
            if (destruir == false)
            {
                this.gameObject.SetActive(false);

            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
