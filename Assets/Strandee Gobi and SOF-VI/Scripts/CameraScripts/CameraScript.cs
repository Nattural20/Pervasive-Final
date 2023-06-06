using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;

namespace Hamish
{
    public class CameraScript : MonoBehaviour
    {
        [SerializeField]private Vector3 offset;
        private float smoothTime = 0.25f;
        private Vector3 velocity = Vector3.zero;
        [SerializeField] private Transform gobi;
        [SerializeField] private Transform sofvi;

        private GameState state = GameState.TitleScreen;

        // -------- Camera Positions ------------
        private Vector3 _default = new Vector3(0f, 0f, 10f);
        private Vector3 _startScreen = new Vector3(1f, 3f, -8f);
        private Vector3 _cinematic = new Vector3(-5f, -20f, 30f);

        private void Awake()
        {
            GameManager.triggerPan += ChangeStateCinematic;
            EventManager.leftScenic += ChangeStateDefault;
            EventManager.enteredScenic += ChangeStateCinematicStart;
            EventManager.momentHasEnded += ChangeStateDefault;
            GameManager.gameStart += ChangeStateDefault;
        }

        void Update()
        {
            UpdateState(state);
        }

        private void UpdateState(GameState newState)
        {
            newState = state;
            switch (newState)
            {
                case GameState.FollowPlayer:
                    ChangeOffset(_default, 4);
                    FollowTarget(gobi);
                    break;
                case GameState.TitleScreen:
                    ChangeOffset(_startScreen, 4);
                    break;
                case GameState.CompanionDeath:
                    break;
                case GameState.CinematicStart:
                    ChangeOffset(_default, 4);
                    FollowTarget(sofvi);
                    break;
                case GameState.Cinematic:
                    ChangeOffset(_cinematic);
                    FollowTarget(sofvi);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }
        }

        private void FollowTarget(Transform target)
        {
            Vector3 targetPosition = target.position - offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }

        private void ChangeOffset(Vector3 position)
        {
            offset = Vector3.MoveTowards(offset, position, 1.5f * Time.deltaTime);
        }

        private void ChangeOffset(Vector3 position, float speed)
        {
            offset = Vector3.MoveTowards(offset, position, speed * Time.deltaTime);
        }

        #region ChangeState
        private void ChangeStateDefault()
        {
            state = GameState.FollowPlayer;
        }
        private void ChangeStateStart()
        {
            state = GameState.TitleScreen;
        }
        private void ChangeStateCinematic()
        {
            state = GameState.Cinematic;
        }
        private void ChangeStateCinematicStart()
        {
            state = GameState.CinematicStart;
        }
        private void ChangeStateDeath()
        {
            state = GameState.CompanionDeath;
        }
        #endregion

        private void OnDisable()
        {
            GameManager.triggerPan -= ChangeStateCinematic;
            EventManager.leftScenic -= ChangeStateDefault;
            EventManager.momentHasEnded -= ChangeStateDefault;
            EventManager.enteredScenic -= ChangeStateCinematicStart;
        }

        private enum GameState
        {
            FollowPlayer,
            TitleScreen,
            CompanionDeath,
            CinematicStart,
            Cinematic
        }
    }

}