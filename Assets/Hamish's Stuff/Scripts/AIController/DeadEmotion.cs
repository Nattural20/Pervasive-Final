using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEmotion : AIEmotions
{
    public override AIEmotions RunCurrentState()
    {
        return this;
    }
}
