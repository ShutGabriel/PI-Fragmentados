using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class TutorialController : MonoBehaviour
{
    [SerializeField] public GameObject[] button;
    GameObject BT_Next;
    [SerializeField] Slider BarraProgresso2;

    [SerializeField] private TextMeshProUGUI mensagemTexto;

    private void Start()
    {
        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(true);
        }


        this.BarraProgresso2.gameObject.SetActive(false);

    }

    public void jogar()
    {
        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(false);
        }

        this.BarraProgresso2.gameObject.SetActive(true);
        this.mensagemTexto.gameObject.SetActive(true);
        this.mensagemTexto.text = "carregango...";
       
        StartCoroutine(CarregarCena());
    }

    private IEnumerator CarregarCena()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Boss_Mapinguari");
        while (!asyncOperation.isDone)
        {
            this.BarraProgresso2.value = asyncOperation.progress;
            yield return null;
        }



    }
}
