using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

namespace Hamish.AI
{
    /// <summary>
    /// This is for when the Companion is neutral
    /// </summary>
    /// <returns></returns>
    public class NeutralEmotion : Emotion
    {
        private Quaternion _rotationAngle = Quaternion.identity;
        private float _yAngle;
        private bool _amIDead;

        public NeutralEmotion(AIController aiController) : base(aiController)
        {
            _amIDead = false;
            EventManager.sofviHasDied += ChangeToDead;
        }

        private void ChangeToDead()
        {
            _amIDead = true;
        }

        public override Emotion RunCurrentEmotion()
        {
            aiController.FollowPlayer(5.0f, 0.5f);

            if(_amIDead)
                return new DeadEmotion(aiController);

            if(aiController.transform.rotation != _rotationAngle)
            {
                _yAngle = Mathf.SmoothDamp(aiController.transform.rotation.y, _rotationAngle.y, ref _rotationAngle.y, 0.025f);
                aiController.transform.rotation = Quaternion.Euler(0, _yAngle, 0);
            }


            return this;
        }
    } 
}
