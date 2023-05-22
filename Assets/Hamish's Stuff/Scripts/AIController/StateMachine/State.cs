using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected AI_Script _aiScript;

    public State(AI_Script aiScript)
    {
        _aiScript = aiScript;
    }

    public abstract IEnumerator Start();

    public abstract IEnumerator FollowPlayer();

    public virtual IEnumerator Execute()
    {
        yield break;
    }
}
