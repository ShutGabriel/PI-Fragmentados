using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapinguariSom : MonoBehaviour
{
    public GameObject[] sonsMapinguari; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ativarSom(int qualSom)
    {
        sonsMapinguari[qualSom].SetActive(true);
    }
}
