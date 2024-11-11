using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomPlayer : MonoBehaviour
{
     public GameObject[] sonsPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ativarSom(int qualSom)
    {
        sonsPlayer[qualSom].SetActive(true);
    }
}
