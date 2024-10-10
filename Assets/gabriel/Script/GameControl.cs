using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using DG.Tweening;

public class GameControl : MonoBehaviour
{
    public Slider _sliderLifeInimigo;
    public int _lifeInimigoInicial;
    public int _lifeInimigoReal;
    public ScMapinguari _scMapinguari;
    // Update is called once per frame
    void Start()
    {
        _sliderLifeInimigo.maxValue = _scMapinguari.hpMax;
        _scMapinguari.Hp = _scMapinguari.hpMax;
        _sliderLifeInimigo.value = _scMapinguari.hpMax;
    }

   public void LifeInimigo()
    {
        _scMapinguari.Hp--;
        _sliderLifeInimigo.DOValue(_scMapinguari.Hp, 0.5f);
    }
}
