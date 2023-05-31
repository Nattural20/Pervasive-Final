using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hamish.AI{
    public abstract class Emotion
    {
        protected AIController aiController;

        public Emotion(AIController _aiController)
        {
            aiController = _aiController;
        }

        public abstract Emotion RunCurrentEmotion();

    }  
}
