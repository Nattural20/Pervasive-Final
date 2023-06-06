using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hamish.AI{
    public class AIController : EmotionController
    {
        [SerializeField] private GameObject _player; //gives the Companion a target to follow

        private Vector3 _velocity = Vector3.zero;
        public float dist { get; private set; }

        [SerializeField] private ParticleSystem[] _particleSystem;
        [SerializeField] public Sprite[] _sprite;
        private Animation _anim;

        private void Awake()
        {
            StartState(new NeutralEmotion(this));
        }

        // Update is called once per frame
        void Update()
        {
            dist = Vector3.Distance(_player.transform.position, transform.position);
            RunStateMachine();
        }

        public void FollowPlayer(float f, float _smoothTime)
        {
            if (dist >= f)
            {
                transform.position = Vector3.SmoothDamp(transform.position, _player.transform.position, ref _velocity, _smoothTime);
            }
        }
        public void FollowPlayer(float f, float _smoothTime, Vector3 target)
        {
            if (dist >= f)
            {
                transform.position = Vector3.SmoothDamp(transform.position, target, ref _velocity, _smoothTime);
            }
        }
        /*
        public void PlayEyeAnimation(string animation)
        {
            _anim.Play(animation);
        }
        */
        private void OnTriggerEnter(Collider other)
        {
            switch (other.tag)
            {
                case "Aversion": //if the AI should be afraid of a location
                    SetState(new UncertainEmotion(this));
                    break;
                case "Marvel":
                    SetState(new MarvelEmotion(this));
                    break;
                default:
                    SetState(new NeutralEmotion(this));
                    break;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            SetState(new NeutralEmotion(this));
        }
    }
}