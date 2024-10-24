using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelecBtnAtivo : MonoBehaviour
{
    public bool btnSet;
    public EventSystem eventS;
    public GameObject UltimoBtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setActiveBtn();
    }

    public void setActiveBtn()
    {
        if (btnSet == false)
        {
            eventS.SetSelectedGameObject(UltimoBtn);
            btnSet = true;
        }

        if (eventS.currentSelectedGameObject != null)
        {
            UltimoBtn = eventS.currentSelectedGameObject;
        }

        VerificaSelectVazil();
    }

    public void VerificaSelectVazil()
    {
        if (eventS.currentSelectedGameObject == null)
        {
            btnSet = false;
        }
    }
}
