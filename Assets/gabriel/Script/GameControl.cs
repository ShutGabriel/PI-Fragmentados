using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameControl : MonoBehaviour
{

    [Header("ControleVidaBoss")]
    public Slider _sliderLifeInimigo;
    public int _lifeInimigoInicial;
    public int _lifeInimigoReal;
    public ScMapinguari _scMapinguari;

    [Header("ControleVidaPlayer")]
    public Slider _sliderLifePlayer;
    public int _lifePlayerInicial;
    public int _lifePlayerReal;
    public int _vidaTest;
    public Moveplayer _Moveplayer;

    [Header("gameOverControle")]
    public GameObject telaGameOver;

    // Update is called once per frame
    void Start()
    {
        _sliderLifeInimigo.maxValue = _scMapinguari.hpMax;
        _scMapinguari.Hp = _scMapinguari.hpMax;
        _sliderLifeInimigo.value = _scMapinguari.hpMax;
        /*
        _vidaTest = 50;
        _sliderLifePlayer.maxValue = _vidaTest;
        _sliderLifePlayer.value = _vidaTest;
        */
    }

    private void Update()
    {

    }

    public void LifeInimigo()
    {
        _scMapinguari.Hp--;
        _sliderLifeInimigo.DOValue(_scMapinguari.Hp, 0.5f);
    }

    public void LifePlayer()
    {
        _vidaTest -= 5;
        _sliderLifePlayer.DOValue(_vidaTest,0.5f);

    }

    public void GameOver()
    {
        telaGameOver.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Boss_Mapinguari");
    }

    public void MenuLoad()
    {
        SceneManager.LoadScene("Gabriel-Teste");
    }
}
