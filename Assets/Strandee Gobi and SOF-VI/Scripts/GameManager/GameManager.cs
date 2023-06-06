using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

namespace Hamish
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance; //Creates a static instance for other scripts to call

        [SerializeField] private GameObject _player;
        [SerializeField] private AudioSource[] _playerMusic;

        public static event Action triggerPan;

        private void Awake()
        {
            if (Instance != null)
                Destroy(this.gameObject);
            Instance = this;
            EventManager.enteredScenic += Cinematic;
            EventManager.momentHasEnded += EndCinematic;
            EventManager.leftScenic += BreakCinematic;

            _playerMusic = _player.GetComponentsInChildren<AudioSource>();
        }


        private void Start()
        {
            for (int i = 0; i < _playerMusic.Length; i++)
            {
                _playerMusic[i].volume = 0f;
                _playerMusic[i].Play();
                Debug.Log(_playerMusic[i] + " Is playing");
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void hideStartScreen(GameObject canvas)
        {
            canvas.SetActive(false);
        }

        #region Cinematic
        private void Cinematic()
        {
            StartCoroutine("MomentOfAFracturedWorld");
        }

        private IEnumerator MomentOfAFracturedWorld()
        {
            //Phase 1
            while (_playerMusic[0].volume < 1.0f) 
            {
                _playerMusic[0].volume += 0.001f;
                yield return null;
            }
            yield return new WaitForSeconds(3f);

            //Phase 2

            EventManager.TogglePlayer();
            triggerPan?.Invoke();
            while (_playerMusic[1].volume < 1.0f)
            {
                _playerMusic[1].volume += 0.001f;
                yield return null;
            }

            yield return new WaitForSeconds(10f);

            while (_playerMusic[1].volume > 0.0f && _playerMusic[0].volume > 0.0f)
            {
                _playerMusic[1].volume -= 0.001f;
                _playerMusic[0].volume -= 0.001f;
                yield return null;
            }
            EventManager.TogglePlayer();
            EventManager.MomentHasEnded();


            Debug.Log("Moment Has Ended");
        }

        private void BreakCinematic()
        {
            StopCoroutine("MomentOfAFracturedWorld");
            _playerMusic[0].volume = 0.0f;
            _playerMusic[0].volume = 0.0f;
        }


        private void EndCinematic()
        {
            _playerMusic[0].volume = 0.0f;
            _playerMusic[0].volume = 0.0f;
        }
        #endregion

        private void OnDisable()
        {
            EventManager.enteredScenic -= Cinematic;
            EventManager.enteredScenic -= BreakCinematic;
        }
    }
}

