using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesativarArea : MonoBehaviour
{
    public AreaDanoMapinguari danoMapinguari;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void desativarObj()
    {
        this.gameObject.SetActive(false);
        danoMapinguari.DanoAplicado = false;
    }
}
