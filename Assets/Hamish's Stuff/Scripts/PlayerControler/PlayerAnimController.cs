using Amatorii_Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private Animator _anim;
    private PlayerController1 _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _playerController= GetComponent<PlayerController1>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
