using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Emotion
{
    protected AIController aiController;

    public Emotion(AIController _aiController)
    {
        aiController = _aiController;
    }

    public abstract Emotion RunCurrentEmotion();

}
