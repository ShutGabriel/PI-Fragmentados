using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class Moveplayer : MonoBehaviour
{

    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Vector2 _move;
    [SerializeField] float _forceJump;
    public GameObject bala;
    public GameObject shotgunbullet;
    public Transform bulletPoint;
    public Transform bulletPointCima;
    private bool _canshoot = true;
    public float shootDelay = 0.5f;
    bool _facingRight;
    public bool _checkground;

    public Animator _animator;
    public bool shootanim;

    [Header("StatosPlayer")]
    public int hp;
    public Slider sliderHpPlayer;
    public GameControl gameControl;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        gameControl = GameObject.Find("Main Camera").GetComponent<GameControl>();
        sliderHpPlayer = GameObject.Find("SliderPlayer").GetComponent<Slider>();
        sliderHpPlayer.maxValue = hp;
    }

    // Update is called once per frame
    void Update()
    {

        _rb.velocity = new Vector2(_move.x * _speed, _rb.velocity.y);

        if (_move.x > 0 && _facingRight == true)
        {
            flip();
        }
        else if (_move.x < 0 && _facingRight == false)
        {
            flip();
        }

        animControl();
        controleHp();
    }

    public void controleHp()
    {
        sliderHpPlayer.value = hp;

        if (hp <= 0)
        {
            gameControl.GameOver();
        }
    }

    public void Dano(int dano)
    {
        hp -= dano;
        _animator.SetLayerWeight(2, 1);
        Invoke("DesativarDano", 0.3f);
    }

    public void DesativarDano()
    {
        _animator.SetLayerWeight(2, 0);

    }

    public void SetMove(InputAction.CallbackContext value)
    {
        _move = value.ReadValue<Vector2>();
    }

    void flip()
    {
        _facingRight = !_facingRight;
        float x = transform.localScale.x;
        x *= -1;

        transform.localScale = new Vector2(x, transform.localScale.y);
    }

    public void SetJump(InputAction.CallbackContext value)
    {
        if (_checkground == true)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 0);
            _rb.AddForce(Vector2.up * _forceJump, ForceMode2D.Impulse);
            _animator.SetTrigger("Jump");
        }
    }

    public void shoot()
    {
        _animator.SetBool("ataqueBool", true);
        Invoke("Shootfalse", 0.5f);
    }

    public void shotgozo()
    {
        _animator.SetBool("ataqueBool", true);
        Invoke("shotgunblast", 0.5f);
    }

    public void bullet()
    {        
        GameObject bala = BalaPool.SharedInstance.GetPooledObject();
        if (bala != null)
        {          
            bala.transform.position = bulletPoint.position;
            bala.GetComponent<ShootAttack>().timerativado = true;
            bala.SetActive(true);
            bala.GetComponent<ShootAttack>().direcao = transform.localScale.x;
        }
        else
        {

        }
        //Instantiate(bala, bulletPoint.position, bala.transform.rotation);

    }

    public void Shootfalse()
    {
        _animator.SetBool("ataqueBool", false);        
    }

    public void animControl()
    {
        if (_move.x != 0)
        {
            _animator.SetBool("Walk", true);
        }
        else
        {

            _animator.SetBool("Walk", false);
        }
        _animator.SetInteger("speedYint", (int)_rb.velocity.y);
        _animator.SetFloat("speedY", _rb.velocity.y);
        _animator.SetBool("noChao", _checkground);
    }

    public void shotgunblast()
    {
        GameObject bala = Instantiate(shotgunbullet, bulletPoint.position, shotgunbullet.transform.rotation);
        bala.GetComponent<Capsulescript>().direction = transform.localScale.x;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            _checkground = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            _checkground = false;
        }
    }
}