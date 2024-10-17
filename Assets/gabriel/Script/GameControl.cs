using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
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
    public Moveplayer _Moveplayer;
    // Update is called once per frame
    void Start()
    {
        _sliderLifeInimigo.maxValue = _scMapinguari.hpMax;
        _scMapinguari.Hp = _scMapinguari.hpMax;
        _sliderLifeInimigo.value = _scMapinguari.hpMax;

        
        _sliderLifePlayer.maxValue = _Moveplayer.healthpoint;
        _sliderLifePlayer.value = _Moveplayer.healthpoint;
    }

   public void LifeInimigo()
    {
        _scMapinguari.Hp--;
        _sliderLifeInimigo.DOValue(_scMapinguari.Hp, 0.5f);
    }

    public void LifePlayer()
    {
        _Moveplayer.healthpoint -= 5;
        _sliderLifePlayer.DOValue(_Moveplayer.healthpoint,0.5f);

    }
}
