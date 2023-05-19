using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIEmotions : MonoBehaviour
{
    protected AIController AIController;

    public AIEmotions(AIController aicontroller)
    {
        AIController = aicontroller;
    }

    public abstract AIEmotions RunCurrentState();
}
