using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueAnim : MonoBehaviour
{

    public Moveplayer _moveplayer;
    
    // Start is called before the first frame update
    

    public void shoot()
    {
        if (_moveplayer.qualTiro == 0)
        {
            _moveplayer.bullet();

        }
        else
        {
            _moveplayer.shotgunblast();
        }
    }





   


      
}
