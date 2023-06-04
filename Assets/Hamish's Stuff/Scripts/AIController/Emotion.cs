using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hamish.AI{
    /// <summary>
    /// This is the Parent Class for all the Emotion States
    /// </summary>
    public abstract class Emotion 
    {
        protected AIController aiController;
        //protected Sprite _eyeSprite;

        public Emotion(AIController _aiController)
        {
            aiController = _aiController;

        }

        public abstract Emotion RunCurrentEmotion();

    }  
}
