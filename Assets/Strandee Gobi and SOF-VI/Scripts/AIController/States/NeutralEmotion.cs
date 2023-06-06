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

        public NeutralEmotion(AIController aiController) : base(aiController)
        {

        }

        public override Emotion RunCurrentEmotion()
        {
            aiController.FollowPlayer(5.0f, 0.5f);

            if(aiController.transform.rotation != _rotationAngle)
            {
                _yAngle = Mathf.SmoothDamp(aiController.transform.rotation.y, _rotationAngle.y, ref _rotationAngle.y, 0.025f);
                aiController.transform.rotation = Quaternion.Euler(0, _yAngle, 0);
            }


            return this;
        }
    } 
}
