using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class MenuController : MonoBehaviour
{
    public List<Transform> menu1 = new List<Transform>();
    public List<Transform> menu2 = new List<Transform>();

    private void Start()
    {
        for (int i = 0; i < menu1.Count; i++)
        {
            menu1[i].localScale = new Vector2(0, 0);
        }
        for (int i = 0; i < menu2.Count; i++)
        {
            menu2[i].localScale = new Vector2(0, 0);

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

        for (int i = 0; i < menu2.Count; i++)
        {
            menu2[i].DOScale(1.5f, .25f);
            yield return new WaitForSeconds(.25f);
            menu2[i].DOScale(1f, .25f);
        }
    }
}



