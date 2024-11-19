using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] button; 
    GameObject BT_Play;
    GameObject Bt_Options;
    GameObject BT_Quit;
    [SerializeField]
    private Slider BarraProgresso;

    [SerializeField]
    private TextMeshProUGUI mensagemTexto;

    private void Start()
    {
        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(true);
        }

       
        this.BarraProgresso.gameObject.SetActive(false);
       
    }

    public void jogar()
    {
        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(false);
        }

        this.BarraProgresso.gameObject.SetActive(true);
        this.mensagemTexto.gameObject.SetActive(true);
        this.mensagemTexto.text = "carregando...";
        
        StartCoroutine(CarregarCena());

    }
    private IEnumerator CarregarCena()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Gabriel-Tutorial");
        while (!asyncOperation.isDone)
        {
            this.BarraProgresso.value = asyncOperation.progress;
            yield return null;
        }
    }

    public void sairJogo()
    {
        Application.Quit();
    }
}