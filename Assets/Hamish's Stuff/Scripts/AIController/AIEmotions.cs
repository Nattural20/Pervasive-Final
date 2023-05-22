using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIEmotions : MonoBehaviour
{
    protected AIController aiController;

    public AIEmotions(AIController aicontroller) //I'm trying to allow scripts that inherit from AIEmotions access to AIController's functions
    {
        aiController = aicontroller;
    }

    public abstract AIEmotions RunCurrentState();


}
