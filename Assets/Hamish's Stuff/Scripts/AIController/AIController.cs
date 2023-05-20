using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] private GameObject _player; //gives the Companion a target to follow

    private Vector3 _velocity = Vector3.zero; 
    private float _smoothTime = 0.25f;

    [SerializeField] private AIEmotions currentEmotion; //Initializes the state machine
    [SerializeField] private AIEmotions[] emotions;
    /*
    private NeutralEmotion _neutralEmotion;
    private UncertainEmotion _uncaertainEmotion;
    */
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        AIEmotions nextState = currentEmotion?.RunCurrentState();

        if(nextState != null)
        {
            //switch to next state
            switch (nextState)
            {
                case NeutralEmotion: //This is companion's default state
                    ChangeEmotionToTarget(nextState);
                    FollowPlayer(5.0f);
                    Debug.Log(currentEmotion);
                    break;
                case UncertainEmotion:
                    ChangeEmotionToTarget(nextState);
                    break;
                case MarvelEmotion:
                    ChangeEmotionToTarget(nextState);
                    break;
                case DeadEmotion:
                    ChangeEmotionToTarget(nextState);
                    break;

            }
        }
    }

    private void ChangeEmotionToTarget(AIEmotions nextState)
    {
        Debug.Log(nextState);
        currentEmotion = nextState;
    }

    private void FollowPlayer(float f)
    {
        float _dist = Vector3.Distance(_player.transform.position, transform.position);
        if (_dist >= f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, _player.transform.position, ref _velocity, _smoothTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Aversion": //if the AI should be afraid of a location
                Debug.Log("AAAAAH");
                //change emotion to uncertain
                //ChangeEmotionToTarget(UncertainEmotion);
                ChangeEmotionToTarget(emotions[1]);
                break;
        }
    }
}
