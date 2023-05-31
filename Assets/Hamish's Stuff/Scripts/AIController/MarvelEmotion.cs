using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hamish.AI
{
    /// <summary>
    /// This is for when the Companion sees the sprawling landscape and stops to look at it
    /// </summary>
    /// <returns>
    /// </returns>
    public class MarvelEmotion : Emotion
    {
        private Emotion _neutralEmotion;
        private bool _ttm;
        private Vector3 _restingPos;
        public Vector3 _velocity = Vector3.zero;

        public MarvelEmotion(AIController aiController) : base(aiController)
        {
            _ttm = false;
            _neutralEmotion = new NeutralEmotion(aiController);
            EventManager.momentHasEnded += TimeToMoveOn;
            _restingPos = new Vector3(aiController.transform.position.x, 1, 0);
        }

        public override Emotion RunCurrentEmotion()
        {
            if (aiController.dist >= 35)
            {
                EventManager.CompanionFriendship(false);
                Debug.Log("Companion: Fuck You");
                return _neutralEmotion;
            }
            if (_ttm)
            {
                EventManager.CompanionFriendship(true);
                Debug.Log("Companion: Thank You");
                return _neutralEmotion;
            }
            aiController.transform.position = Vector3.SmoothDamp(aiController.transform.position, _restingPos, ref _velocity, 0.5f);

            return this;
        }

        private void TimeToMoveOn()
        {
            _ttm = true;
        }

        private void OnDisable()
        {
            EventManager.leftCorruption -= TimeToMoveOn;
        }
    } 
}
