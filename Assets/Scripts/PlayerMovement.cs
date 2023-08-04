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

    //�ִϸ��̼� ��Ʈ�ѷ��� ���� �� �� �ҷ���
    public RuntimeAnimatorController[] animCon;
    //public GameManager gameManager; //���ӸŴ����� ����
    //���ϵ����� ������ ���� �ְ� ���� �� ���� ���� ����
    public float maxPosition = 0; 


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    //�ִϸ����� Ȱ��ȭ �� �� ������
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

            ////ĳ���Ͱ� ���̿� ��������� ���̰� 10 �̻��� ��
            //if (maxPosition - transform.position.y > 5f)
            //{
            //    maxPosition = 0;
            //    Debug.Log("maxPosition");
            //}                       

            //���ϵ�����
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
        // ���� �ε����� ��Ʈ���ŷ� �ִϸ��̼� ����
        else if (IsGrounded() == false) 
        {
            // �÷��̾� �������� velocity ���� Ȯ���ؼ� ���̰� -20 ���Ϸ� �������� ���� ����
            if (rb.velocity.y < -20.0f)
            {
                // while ���� ����غ����� �׽�Ʈ�� - ����� �ȵ�
                while (IsGrounded()) {
                    dirX = -30.0f;
                }
                    anim.SetTrigger("death");
            }
            
            else
            {
                //Ȯ�ο� : ���߿� �����
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
         // ������Ʈ�� ������ �߰��ؼ� velovity ������ ���� ��ȯ�� �׽�Ʈ �غ��� ������ ���°� �ȳѾ
        else if (rb.velocity.y < -20.0f)
        {
            if (IsGrounded()) {
                Debug.Log("dead");
            
            }
            else {
            anim.SetTrigger("death");
            
            }
                Debug.Log("����");

        }


        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    //�ǴϽö��ο� ������
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Finish")
    //    {
    //        gameManager.GameOver();//���ӿ���
    //    }
    //}

    //�ǴϽö��ο� ������
    private void OnTriggerEnter2D(Collider2D potal)
    {
        if (potal.gameObject.tag == "Finish")
        {
            GameManager.instance.OnPlayerArrived();
            Debug.Log("�浹");
        }
    }
}
