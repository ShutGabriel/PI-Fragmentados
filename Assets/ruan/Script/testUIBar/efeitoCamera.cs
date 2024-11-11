using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class efeitoCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
   

    }

    public void TremerTela()
    {
        transform.DOShakePosition(0.5f, 0.3f);
    }


}
