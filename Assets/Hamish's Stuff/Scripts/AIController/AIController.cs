using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Vector3 _velocity = Vector3.zero;
    private float _smoothTime = 0.25f;
    private float _tetherDistance;

    AIEmotions currentEmotion;

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RunStateMachine();
        FollowPlayer();
    }

    private void RunStateMachine()
    {
        AIEmotions nextState = currentEmotion?.RunCurrentState();

        if(nextState != null)
        {
            //switch to next state
        }
    }

    private void ChangeEmotionToTarget(AIEmotions nextState)
    {
        currentEmotion = nextState;
    }
    private void FollowPlayer()
    {
        float _dist = Vector3.Distance(_player.transform.position, transform.position);
        if (_dist >= _tetherDistance)
        {
            transform.position = Vector3.SmoothDamp(transform.position, _player.transform.position, ref _velocity, _smoothTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Aversion":
                Debug.Log("AAAAAH");
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
    }
}
