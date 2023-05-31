using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hamish.AI
{
    public abstract class EmotionController : MonoBehaviour
    {
        protected Emotion _emotion;

        private Emotion currentEmotion;

        public void StartState(Emotion emotion)
        {
            _emotion = emotion;
            currentEmotion = emotion;
            _emotion.RunCurrentEmotion();
        }

        public void RunStateMachine()
        {
            Emotion nextEmotion = currentEmotion?.RunCurrentEmotion();

            switch (nextEmotion)
            {
                case NeutralEmotion:
                    SetState(nextEmotion);
                    break;
                case UncertainEmotion:
                    SetState(nextEmotion);
                    break;
                case MarvelEmotion:
                    SetState(nextEmotion);
                    break;
                case DeadEmotion:
                    SetState(nextEmotion);
                    break;
            }
            Debug.Log("Emotion: " + nextEmotion.ToString());
        }

        public void SetState(Emotion emotion)
        {
            currentEmotion = emotion;
        }
    } 
}
