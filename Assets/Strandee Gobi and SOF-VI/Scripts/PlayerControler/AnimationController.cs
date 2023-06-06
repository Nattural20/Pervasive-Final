using Hamish.AI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Amatorii_Controller
{
    /// <summary>
    /// If anyone changes this or the animator's state machine,
    /// I will commit a hate crime agaisnt you and your family
    /// </summary>
    public class AnimationController : MonoBehaviour
    {
        private PlayerController1 _p;
        private Animator _anim;
        [SerializeField] private bool _facingRight = false;
        [SerializeField]private bool _moving = false;

        private void Start()
        {
            _p = GetComponent<PlayerController1>();
            _anim = GetComponentInChildren<Animator>();
        }

        void Update()
        {
            if(_p.Input.X == -1)
            {
                _facingRight = false;
            }
            else if(_p.Input.X == 1)
            {
                _facingRight = true;
            }
            else
            {
                _moving = false;
            }

            if(_p._currentVerticalSpeed < 0)
            {
                StartCoroutine(FallingAnimation());
                return;
            }

            if (_p.JumpingThisFrame)
            {
                StartCoroutine(JumpAnimation());
            }

            if (_p.Grounded)
            {
                if(_p.Input.X != 0)
                {
                    if (_moving)
                    {
                        RunLoop();
                        return;
                    }
                    StartCoroutine(RunAnimation(_p.Input.X));
                    return;
                }
                else
                {
                    if(_facingRight)
                        _anim.Play("metarig_Character_Idle_Right");
                    else
                        _anim.Play("metarig_Character_Idle_Left");
                }
            }
        }

        private void RunLoop()
        {
            if (_p.Input.X == 0)
            {
                _moving = false;
                return;
            }
            if (_facingRight)
                _anim.Play("metarig_Character_RunningLoop_Right");
            else
                _anim.Play("metarig_Character_RunningLoop_Left");
        }

        private IEnumerator JumpAnimation()
        {
            if (_facingRight)
                _anim.Play("metarig_Character_Jump_Right");
            else
                _anim.Play("metarig_Character_Jump_Left");

            float animationLength = _anim.GetCurrentAnimatorStateInfo(0).length;


            yield return new WaitForSeconds(animationLength);
        }

        private IEnumerator FallingAnimation()
        {
            if (_facingRight)
                _anim.Play("metarig_Character_Falling_Right");
            else
                _anim.Play("metarig_Character_Falling_Left");
            float animationLength = _anim.GetCurrentAnimatorStateInfo(0).length;


            yield return new WaitForSeconds(animationLength);
        }

        private IEnumerator RunAnimation(float i) //if I is negative, the player is facing left
        {
            if(i == -1)
            {
                if(_facingRight)
                    _anim.Play("metarig_Character_Switch_RightLeft");
                else
                    _anim.Play("metarig_Character_IdleRun_Left");
            }
            else if (i == 1)
            {
                if (!_facingRight)
                    _anim.Play("metarig_Character_Switch_LeftRight");
                else
                    _anim.Play("metarig_Character_IdleRun_Right");
                _facingRight = true;
            }
            yield return new WaitForSeconds(_anim.GetCurrentAnimatorStateInfo(0).length + _anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            _moving = true;
        }
    }
}