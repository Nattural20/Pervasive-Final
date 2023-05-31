using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Amatorii_Controller
{
    public abstract class AnimationState
    {
        public AnimationState()
        {

        }

        public abstract AnimationState ExecuteAnimation();

    }
}

