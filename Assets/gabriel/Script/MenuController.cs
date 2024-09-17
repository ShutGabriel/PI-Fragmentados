using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class MenuController : MonoBehaviour
{
    public List<Transform> menu1 = new List<Transform>();

    private void Start()
    {
        for (int i = 0; i < menu1.Count; i++)
        {
            menu1[i].localScale = new Vector2(0, 0);
        }
       
        StartCoroutine(TimeONMenu());
    }



    public void LoadScene(string cena)
    {
        SceneManager.LoadScene(cena);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator TimeONMenu()
    {
        for (int i = 0; i < menu1.Count; i++)
        {
            menu1[i].DOScale(1.5f, .25f);
            yield return new WaitForSeconds(.25f);
            menu1[i].DOScale(1f, .25f);
        }

        
    }
}

public class MenuPrincipalManager : MonoBehaviour
{
    private string Jogo;
    private GameObject painelOpcoes;
    private GameObject painelMenuInicial;

    public void jogar()
    {
        SceneManager.LoadScene(Jogo);



    }
    public void AbrirOptions()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);

    }
    public void FecharOptions()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);

    }

}


