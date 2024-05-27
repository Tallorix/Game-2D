using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaerMove : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Text _countAppleText;

    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _jumpforce;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _sprite;

    private string _namePar = "isGoing";
    private string _nameParJump = "isJump";
    private bool _isGround;
    private string _nameGround = "Ground";
    private string _nameApple = "Apple";
    private string _nameFinish = "Finish";

    private int _countApple = 0;

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rb.AddForce(Vector2.up * _jumpforce, ForceMode2D.Impulse);
            _animator.SetTrigger(_nameParJump);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _animator.SetBool(_namePar, true);
        }
        else
        {
            _animator.SetBool(_namePar, false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _sprite.flipX = true;
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _sprite.flipX = false;
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _nameGround)
        {
            _isGround = true;
        }


        if (collision.gameObject.tag == _nameApple)
        {
            _countApple++;
            _countAppleText.text = _countApple.ToString();

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == _nameFinish)
        {
            _winPanel.SetActive(true);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _nameGround)
        {
            _isGround = false;
        }
    }
    

    private void OnDestroy()
    {
        _restartButton.gameObject.SetActive(true);
    }
}
