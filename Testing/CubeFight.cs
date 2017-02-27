using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CubeFight : MonoBehaviour {

    Animator anim;
    Transform _transform;
    CharacterController _controller;


    public float jumpSpeed;
    private bool isJump;
    public Slider selfHP;
    public Slider enemyHP;

    private int maxHP = 100;
    public int curHp;

    public float rotateSpeed;
    public float walkSpeed;


    // Use this for initialization
    void Start () {
        _controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        anim.SetBool("Fight", false);
        _transform = transform;
        curHp = maxHP;

        selfHP.maxValue = maxHP;
        selfHP.value = curHp;



    }
	
	// Update is called once per frame
	void Update () {
        UpdateHP();

        if (!_controller.isGrounded)
        {
            _controller.Move(Vector3.down * Time.deltaTime);
        }

        Turn();
        Walk();
        Jump();



        if (Input.GetKey(KeyCode.E))
        {
            anim.SetBool("Fight", true);
        }
        else
        {
            anim.SetBool("Fight", false);
        }


	
	}

    void Turn()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            _transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed, 0);
        }
    }

    void Walk()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0)
        {
            _controller.SimpleMove(_transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * walkSpeed);

        }
    }

    void Jump()
    {
        isJump = false;
        if (!isJump && _controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJump = true;
                transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime);
            }
            else if(!_controller.isGrounded)
            {
                isJump = false;
                _controller.Move(Vector3.down * Time.deltaTime);
            }
        }
    }

    void UpdateHP()
    {
        if (curHp <=0)
        {
            curHp = 0;
        }
        selfHP.value = curHp;
    }



}
