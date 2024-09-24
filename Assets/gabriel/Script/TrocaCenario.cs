using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField]
    GameObject BT_Play;

    [SerializeField]
    private Text MensagemTexto;

    [SerializeField]
    private Slider BarraProgresso;


    public void jogar()
    {
        CarregarCena();

    }
    private void CarregarCena()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Jogo");
        while (!asyncOperation.isDone)
        {
            Debug.Log("Carregamento: " + asyncOperation.progress + "%");
        }
    }
}