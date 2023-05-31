using Amatorii_Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimController : PlayerController1
{
    private Animator _anim;
    private PlayerController1 _playerController;

    private bool _facingRight;
    private bool _moving;

    // Start is called before the first frame update
    void Start()
    {
        _moving = false;
        _facingRight = true;
        _anim = GetComponentInChildren<Animator>();
        //_playerController= GetComponent<PlayerController1>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_playerController.RawMovement.y);
        if (Input.X != 0)
        {
            MovePlayer(Input.X);
            Debug.Log(Input.X);
            return;
        }
        _moving = false;
        if (_facingRight)
        {
            _anim.Play("metarig_Character_Idle_Right");
        }
        else
        {
            _anim.Play("metarig_Character_Idle_Left");
        }
    }

    private void MovePlayer(float direct)
    {
        if (_moving)
        {
            if(direct >= 1)
            {
                _anim.Play("metarig_Character_RunningLoop_Right");
                return;
            }
            else
            {
                _anim.Play("metarig_Character_RunningLoop_Left");
                return;
            }
        }
        if(direct >= 1)
        {
            if (_facingRight)
            {
                _anim.Play("metarig_Character_IdleRun_Right");
            }
            else
            {
                _anim.Play("metarig_Character_Switch_RightLeft");
            }
            _facingRight = true;
            _moving = true;
        }
        else if(direct >= -1)
        {
            if (!_facingRight)
            {
                _anim.Play("metarig_Character_IdleRun_Left");
            }
            else
            {
                _anim.Play("metarig_Character_Switch_LeftRight");
            }
            _facingRight = false;
            _moving = true;
        }

    }
}
