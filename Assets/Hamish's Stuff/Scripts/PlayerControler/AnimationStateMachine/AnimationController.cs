using Hamish.AI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Amatorii_Controller
{
    public class AnimationController : MonoBehaviour
    {
        private PlayerController1 _p;
        private Animator _anim;
        private bool _facingRight = false;

        private void Start()
        {
            _p = GetComponent<PlayerController1>();
            _anim = GetComponentInChildren<Animator>();
        }

        void Update()
        {
            if (_p.Grounded)
            {
                if(_p.Input.X != 0)
                {
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

        private IEnumerator RunAnimation(float i) //if I is negative, the player is facing left
        {
            if(i == -1)
            {
                if(_facingRight)
                    _anim.Play("metarig_Character_Switch_RightLeft");
                else
                    _anim.Play("metarig_Character_IdleRun_Left");
                _facingRight = false;
            }
            else
            {
                if (!_facingRight)
                    _anim.Play("metarig_Character_Switch_LeftRight");
                else
                    _anim.Play("metarig_Character_IdleRun_Right");
                _facingRight = true;
            }
            float animationLength = _anim.GetCurrentAnimatorStateInfo(0).length;

            yield return new WaitForSeconds(animationLength);

                if (_facingRight)
                    _anim.Play("metarig_Character_RunningLoop_Right");
                else
                    _anim.Play("metarig_Character_RunningLoop_Left");
            
        }
    }
}

