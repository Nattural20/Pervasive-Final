using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] private GameObject _player; //gives the Companion a target to follow

    private Vector3 _velocity = Vector3.zero; 
    public float _dist;
    private bool ubool = false;


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
        _dist = Vector3.Distance(_player.transform.position, transform.position);

        RunStateMachine();
    }

    private void RunStateMachine()
    {
        AIEmotions nextState = currentEmotion?.RunCurrentState();

        if(nextState != null)
        {
            //switch to next sate
            switch (nextState)
            {
                case NeutralEmotion: //This is companion's default state
                    ChangeEmotionToTarget(nextState);
                    ubool = false;
                    FollowPlayer(5.0f, 0.5f);
                    break;
                case UncertainEmotion:
                    if(_dist >= 20 || ubool)
                    {
                        FollowPlayer(2.5f, 0.1f);
                        ubool = true;
                    }
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

    public void FollowPlayer(float f, float _smoothTime)
    {
        if (_dist >= f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, _player.transform.position, ref _velocity, _smoothTime);
        }
    }

    public void FollowPlayer(float _smoothTime)
    {
        transform.position = Vector3.SmoothDamp(transform.position, _player.transform.position, ref _velocity, _smoothTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Aversion": //if the AI should be afraid of a location
                ChangeEmotionToTarget(emotions[1]);
                break;
            default:
                ChangeEmotionToTarget(emotions[0]);
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ChangeEmotionToTarget(emotions[0]);
    }
}
