using System;
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
        private Vector3 _sacrifice = new Vector3(375.98f, 90.69f, 0.0f);
        public DeadEmotion(AIController aiController) : base(aiController)
        {
            GameManager.theChoice += PlayDead;
        }

        private void PlayDead()
        {
            aiController.GetComponent<Rigidbody2D>().gravityScale = 1;
        }

        public override Emotion RunCurrentEmotion()
        {
            if(aiController.GetComponent<Rigidbody2D>().gravityScale != 1)
                aiController.FollowPlayer(0f, 0.75f, _sacrifice);

            return this;
        }
    } 
}
