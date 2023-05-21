using Amatorii_Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
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
        _playerController= GetComponent<PlayerController1>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_playerController.RawMovement.y);
        if (_playerController.Input.X != 0)
        {
            MovePlayer(_playerController.Input.X);
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
        /*
        if (_playerController.Input.JumpDown)
        {
            _anim.Play("Jumping");

        }
        if (_playerController._currentVerticalSpeed >= -10)
        {

        }
        if (_playerController.LandingThisFrame)
        {

        }
        */
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
