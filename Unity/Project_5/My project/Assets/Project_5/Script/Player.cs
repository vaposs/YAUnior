using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _jumpForse = 5;
    [SerializeField] private bool _isGround;
    private SpriteRenderer SpriteRenderer;
    private Animator Animator;
    private Rigidbody2D Rigidbody2D;
    private float direction;

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = Input.GetAxis("Horizontal") * _speed;

        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime,0,0);
            Animator.SetFloat("speed",5);
            FlipX();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate((_speed * Time.deltaTime) * -1, 0, 0);
            Animator.SetFloat("speed", 5);
            FlipX();
        }
        else
        {
            Animator.SetFloat("speed", 0);
        }
    }

    private void FlipX()
    {
        if (direction > 0)
        {
            SpriteRenderer.flipX = false;
        }
        else if (direction < 0)
        {
            SpriteRenderer.flipX = true;
        }
        else
        {
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, Rigidbody2D.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        _isGround = true;
        Animator.SetBool("isGroung", true);
    }
}
