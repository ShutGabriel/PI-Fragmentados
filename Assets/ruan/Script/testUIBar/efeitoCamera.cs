using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class efeitoCamera : MonoBehaviour
{
   public Camera cam;
    public bool introFeita;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cameraIntro());
    }

    // Update is called once per frame
    void Update()
    {

        if (introFeita == true)
        {
            //cam.orthographicSize = 4.7f;
        }
    }

    public void TremerTela()
    {
        transform.DOShakePosition(0.5f, 0.3f);
    }

    public IEnumerator cameraIntro()
    {
        yield return new WaitForSeconds(0.8f);
        cam.DOOrthoSize(3,0.3f);
        cam.transform.DOMove(new Vector3(3.27f, -1.01f, -10), 0.3f);
        yield return new WaitForSeconds(0.7f);
        transform.DOShakePosition(1f, 0.3f);
        yield return new WaitForSeconds(0.5f);
        cam.transform.DOMove(new Vector3(0, 0, -10), 0.5f);
        cam.DOOrthoSize(4.7f, 0.3f);

        introFeita = true;
    }


}
