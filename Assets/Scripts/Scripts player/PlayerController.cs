using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator _anim;

    private Rigidbody2D _playerRigidbody2D;
    public float _playerSpeed;
    private float _playerRunSpeed;
    private Vector2 _playerDirection;

    private float _SpeedTime;
    private bool _isRunning;
    private float _CurrentTime;

    private bool _Runned;
    private float _waitTime;
    // Start is called before the first frame update
    void Start()
    {
        
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _playerRunSpeed = _playerSpeed + ((_playerSpeed*3)/5);
        _isRunning = false;
        _Runned = false;
        _SpeedTime = 1f;
        _waitTime = 2f;
        _CurrentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _anim.SetFloat("Horizontal", _playerDirection.x);
        _anim.SetFloat("Vertical", _playerDirection.y);
        _anim.SetFloat("Speed", _playerDirection.magnitude);

        if (_playerDirection != Vector2.zero)
        {
            _anim.SetFloat("Idle_H", _playerDirection.x);
            _anim.SetFloat("Idle_V", _playerDirection.y);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _isRunning = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            _isRunning = false;
        }
    }

    void FixedUpdate()
    {
        _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection * _playerSpeed * Time.fixedDeltaTime);


        // ESSE COMANDO IDENTIFICA SE ESTA CORRENDO

            if (_isRunning == true)         
            {
                _CurrentTime += Time.deltaTime;
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;


        // ESSE COMANDO IDENTIFICA O LIMITE DE CORRIDA

                if (_CurrentTime >= _SpeedTime)
                {
                    _isRunning = false;
                    _CurrentTime = 0f;
                    _Runned = true;
                }

                _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection * _playerRunSpeed * Time.fixedDeltaTime);
            }

        // ESSE COMANDO IDENTIFICA SE NAO ESTA CORRENDO E NEM CANSADO

            else if (_isRunning == false && _Runned == false)
            {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        

        // ESSE COMANDO IDENTIFICA SE ESTA CANSADO

            if (_Runned == true)
            {
                _isRunning = false;
                _CurrentTime += Time.deltaTime;
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;


        // ESSE COMANDO IDENTIFICA O LIMITE DE DESCANSO

            if (_CurrentTime >= _waitTime)
                {
                    _CurrentTime = 0f;
                    _Runned = false;
                }
        }
    }
}
