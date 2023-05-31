using Hamish.AI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Amatorii_Controller
{
    public class AnimationController : MonoBehaviour
    {
        private AnimationState _currentState;
        protected AnimationState _initAnim;


        private void Start()
        {
            //_initAnim = 
        }

        void Update()
        {
            RunAnimation();
        }

        public void RunAnimation()
        {
            AnimationState state = _currentState?.ExecuteAnimation();

            switch(state)
            {
                case StateJump:
                    
                    break;
            }
        }
    }
}

