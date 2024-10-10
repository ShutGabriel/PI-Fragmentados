using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField]
    GameObject BT_Play;

    [SerializeField]
    private Slider BarraProgresso;

    [SerializeField]
    private TextMeshProUGUI mensagemTexto;

    private void Start()
    {

        this.BT_Play.SetActive(true);
        this.BarraProgresso.gameObject.SetActive(false);
       
    }

    public void jogar()
    {
        this.BT_Play.SetActive(false);
        this.BarraProgresso.gameObject.SetActive(true);
        this.mensagemTexto.text = "carregando...";
        
        StartCoroutine(CarregarCena());

    }
    private IEnumerator CarregarCena()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Jogo");
        while (!asyncOperation.isDone)
        {
            this.BarraProgresso.value = asyncOperation.progress;
            yield return null;
        }
    }
}