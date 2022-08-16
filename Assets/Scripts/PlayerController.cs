using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movements();
    }

    private void Movements()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        if (hAxis != 0 || vAxis != 0)
        {
            Vector2 moveVector = new Vector2(hAxis, vAxis);
            moveVector = rb2d.position + moveVector * speed * Time.fixedDeltaTime;

            rb2d.MovePosition(moveVector);
            ShowWalkAnimation(true);
            FlipSR(hAxis);
        }
        else
        {
            ShowWalkAnimation(false);
        }

    }

    private void FlipSR(float hAxis)
    {
        sr.flipX = hAxis < 0;
    }

    private void ShowWalkAnimation(bool isWalk)
    {
        anim.SetBool("IsWalk", isWalk);
    }
}
