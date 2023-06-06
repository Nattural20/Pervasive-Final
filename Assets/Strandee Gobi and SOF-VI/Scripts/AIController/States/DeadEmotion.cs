using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hamish.AI
{
    /// <summary>
    /// This is for when the Companion is dead
    /// </summary>
    /// <returns>
    /// </returns>
    public class DeadEmotion : Emotion
    {
        private Vector3 _sacrifice = new Vector3(343.4f, 88.0f, 0.0f);
        public DeadEmotion(AIController aiController) : base(aiController)
        {

        }

        public override Emotion RunCurrentEmotion()
        {
            aiController.FollowPlayer(0f, 0.75f, _sacrifice);

            return this;
        }
    } 
}
