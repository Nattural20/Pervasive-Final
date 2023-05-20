using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIEmotions : MonoBehaviour
{
    protected AIController AIController;

    public AIEmotions(AIController aicontroller) //I'm trying to allow scripts that inherit from AIEmotions access to AIController's functions
    {
        AIController = aicontroller;
    }

    public abstract AIEmotions RunCurrentState();


}
