using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;


    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float movespeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, runnung, jumping, falling, death }

    //애니메이션 컨트롤러에 저장 된 것 불러옴
    public RuntimeAnimatorController[] animCon;
    //public GameManager gameManager; //게임매니저에 접근
    //낙하데미지 구현을 위한 최고 높이 값 가질 변수 선언
    public float maxPosition = 0; 


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    //애니메이터 활성화 될 때 가져옴
    //void OnEnable()
    //{
    //    anim.runtimeAnimatorController = animCon[GameManager.gm.playerid];
    //}

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            ////캐릭터가 높이와 지면높이의 차이가 10 이상일 때
            //if (maxPosition - transform.position.y > 5f)
            //{
            //    maxPosition = 0;
            //    Debug.Log("maxPosition");
            //}                       

            //낙하데미지
            //else
            //{
            //    if (rb.velocity.y < 0f && maxPosition < transform.position.y)
            //    {
            //        maxPosition = transform.position.y;
            //        Debug.Log("maxPosition");
            //    }
            //}
            Debug.Log("maxPosition");
           
        }
        // 땅에 부딪히면 셋트리거로 애니메이션 실행
        else if (IsGrounded() == false) 
        {
            // 플레이어 떨어질대 velocity 값을 확인해서 높이가 -20 이하로 떨어질때 죽을 조건
            if (rb.velocity.y < -20.0f)
            {
                // while 문을 사용해보려고 테스트함 - 제대로 안됨
                while (IsGrounded()) {
                    dirX = -30.0f;
                }
                    anim.SetTrigger("death");
            }
            
            else
            {
                //확인용 : 공중에 뜬상태
                Debug.Log("fly");
            }

        }

        UpdateAnimationUpdate();

    }

    //private void Die()
    //{
    //    anim.SetTrigger("death");
    //}


    private void UpdateAnimationUpdate()
    {
        MovementState state = MovementState.idle;

        
        if (dirX > 0f)
        {
            state = MovementState.runnung;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.runnung;
            sprite.flipX = true;
        }
        else    
        {
            state = MovementState.idle;
        }
        
         if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
         // 스테이트에 죽음을 추가해서 velovity 값으로 상태 변환을 테스트 해보려 했으나 상태값 안넘어감
        else if (rb.velocity.y < -20.0f)
        {
            if (IsGrounded()) {
                Debug.Log("dead");
            
            }
            else {
            anim.SetTrigger("death");
            
            }
                Debug.Log("도착");

        }


        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    //피니시라인에 들어오면
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Finish")
    //    {
    //        gameManager.GameOver();//게임오버
    //    }
    //}

    //피니시라인에 들어오면
    private void OnTriggerEnter2D(Collider2D potal)
    {
        if (potal.gameObject.tag == "Finish")
        {
            GameManager.instance.OnPlayerArrived();
            Debug.Log("충돌");
        }
    }
}
