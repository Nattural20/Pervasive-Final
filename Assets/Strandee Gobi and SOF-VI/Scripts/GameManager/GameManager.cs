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
        [SerializeField]private float _musicVolume;
        public static event Action triggerPan;
        public static event Action gameStart;

        private IEnumerator momentOfAFracturedWorld;

        private void Awake()
        {
            if (Instance != null)
                Destroy(this.gameObject);
            Instance = this;
            EventManager.enteredScenic += Cinematic;
            EventManager.momentHasEnded += EndCinematic;
            EventManager.leftScenic += BreakCinematic;
            EventManager.sofviHasDied += StopMusicPlayer;
            EventManager.goodChoice += GoodChoice;
            EventManager.goodChoice += BadChoice;

            _playerMusic = _player.GetComponentsInChildren<AudioSource>();
        }



        private void Start()
        {
            for (int i = 0; i < _playerMusic.Length; i++)
            {
                _playerMusic[i].volume = 0f;
                _playerMusic[i].Play();
                Debug.Log(_playerMusic[i].clip);
            }

            _playerMusic[4].Stop();

            _playerMusic[4].volume = 1.0f;

            _playerMusic[0].volume = _musicVolume;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void hideStartScreen(GameObject canvas)
        {
            canvas.SetActive(false);
            StartCoroutine(FadeInMusic(_playerMusic[1]));
            gameStart?.Invoke();
            EventManager.TogglePlayer();
        }

        #region Cinematic
        private void Cinematic()
        {
            momentOfAFracturedWorld = MomentOfAFracturedWorld();
            StartCoroutine(momentOfAFracturedWorld);
        }

        private IEnumerator MomentOfAFracturedWorld()
        {
            //Phase 1
            while (_playerMusic[2].volume < _musicVolume) 
            {
                _playerMusic[2].volume += 0.001f;
                yield return null;
            }
            yield return new WaitForSeconds(5f);

            //Phase 2

            EventManager.TogglePlayer();
            triggerPan?.Invoke();
            while (_playerMusic[3].volume < _musicVolume)
            {
                _playerMusic[3].volume += 0.001f;
                yield return null;
            }

            yield return new WaitForSeconds(10f);

            while (_playerMusic[3].volume > 0.0f && _playerMusic[2].volume > 0.0f)
            {
                _playerMusic[3].volume -= 0.001f;
                _playerMusic[2].volume -= 0.001f;
                yield return null;
            }
            EventManager.TogglePlayer();
            EventManager.MomentHasEnded();

        }

        private void BreakCinematic()
        {
            StopCoroutine(momentOfAFracturedWorld);
            _playerMusic[2].volume = 0.0f;
        }


        private void EndCinematic()
        {
            _playerMusic[2].volume = 0.0f;
            _playerMusic[3].volume = 0.0f;
        }
        #endregion

        #region Music
        ///All tracks should play non stop, adjust volume
        ///First track always playing
        ///Second track play at the start menu
        ///Third when you enter stop and look
        ///Fourth is when the camera begins to move at the stop and look
        ///When Sofvi dies, stop all music

        private void StopMusicPlayer()
        {
            StartCoroutine(PauseMovement());
        }

        private IEnumerator FadeInMusic(AudioSource track){
            while(track.volume !<= _musicVolume){
                track.volume += 0.001f;
                yield return null;
            }
            yield return null;
        }

        private IEnumerator FadeOutMusic(AudioSource track){
            while(track.volume > 0.0f){
                track.volume -= 0.0005f;
                yield return null;
            }
            yield return null;
        }

        #endregion
        
        #region The End
        
        public static event Action theChoice;

        [SerializeField] private AudioClip _shock;

        [SerializeField] private AudioClip _goodMusic;
        [SerializeField] private AudioClip _badMusic;


        private IEnumerator PauseMovement() //This is the end
        {
            EventManager.TogglePlayer();

            yield return new WaitForSeconds(1.0f);

            for(int i = 0; i < _playerMusic.Length; i++){
                StartCoroutine(FadeOutMusic(_playerMusic[i]));
            }
            _playerMusic[4].volume = 1.0f;
            _playerMusic[4].PlayOneShot(_shock);
            yield return new WaitForSeconds(2.0f);
            theChoice?.Invoke();

            yield return new WaitForSeconds(6.0f);
            
            EventManager.TogglePlayer();
            _playerMusic[4].Stop();
        }

        private void BadChoice()
        {
            if(!_playerMusic[4].isPlaying){
                _playerMusic[4].clip = _badMusic;
                _playerMusic[4].Play();
            }
        }

        private void GoodChoice()
        {
            Debug.Log("PLAY FFS");
            if(!_playerMusic[4].isPlaying){
                _playerMusic[4].clip = _goodMusic;
                _playerMusic[4].Play();
            }
        }
        
        #endregion

        private void OnDisable()
        {
            EventManager.enteredScenic -= Cinematic;
            EventManager.momentHasEnded -= EndCinematic;
            EventManager.leftScenic -= BreakCinematic;
            EventManager.sofviHasDied -= StopMusicPlayer;
        }
    }
}

