using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static bool IsGameRunning;
    [SerializeField] private Camera _mainCamera;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
        IsGameRunning = true;
    }

    private void Start()
    {
        _screenBounds = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _mainCamera.transform.position.z));

        //Music Stuff

        _playerMusic = _Player.GetComponentsInChildren<AudioSource>();
        _playerMusic[0].volume = 0f;
        _playerMusic[1].volume = 0f;

        //Background Stuff

        foreach (GameObject obj in levels) LoadChildrenObjects(obj) ;

        
    }

    private void Update()
    {
        _XInput = Input.GetAxisRaw("Horizontal");
        MoveBackground();
        Debug.Log(_inScenicMoment);
        if (_inScenicMoment)
        {
            MomentOfAFracturedWorld();
        }
        else
        {
            if (_playerMusic[0].volume <= 0)
            {
                _musicTime = 10f;
                _playerMusic[0].Stop();
                _playerMusic[1].volume = 0;
            }
            else
            {
                _playerMusic[0].volume -= Time.deltaTime / 1.5f;


            }

            if (_playerMusic[1].volume < 0)
            {
                _musicTime2 = 5f;
                _playerMusic[1].Stop();
                _playerMusic[1].volume = 0;
            }
            else
            {
                _playerMusic[1].volume -= Time.deltaTime / 1.5f;
            }
            camerascript.offset = Vector3.MoveTowards(camerascript.offset, _default, 1.5f * Time.deltaTime);
        }


    }

    private void LateUpdate()
    {
        //Background Stuff
        foreach(GameObject obj in levels)
        {
            RepositionChildrenObjects(obj);
        }
    }

    #region Player
    [Header("---Player---")]
    [SerializeField] private GameObject _Player;
    private float _XInput;

    private void TogglePlayerIsActive()
    {
        /*
        var playerscript = _Player.GetComponent<Amatorii_Controller.PlayerController1>();
        playerscript._active = !playerscript._active;
        */
    }

    #endregion

    #region CameraController
    private bool _inScenicMoment;
    private AudioSource[] _playerMusic;
    private Vector3 _target = new Vector3(6.5f, 12f, -24f);
    private Vector3 _default = new Vector3(0f, 0f, -10f);
    private CameraScript camerascript => _mainCamera.GetComponentInParent<CameraScript>();
    [SerializeField] AudioClip[] _tndnbtg;
    [SerializeField] private float _musicTime = 10f;
    [SerializeField] private float _musicTime2 = 5f;
    public void ScenicTrigger(bool b)
    {
        _inScenicMoment = b;
    }

    private void MomentOfAFracturedWorld()
    {
        if (_musicTime >= 0)
        {
            _musicTime -= Time.deltaTime;
            _playerMusic[0].volume += Time.deltaTime;
            if (!_playerMusic[0].isPlaying)
            {
                _playerMusic[0].Play();
            }
            _playerMusic[0].loop = true;
        }
        else
        {
            _playerMusic[0].loop = false;
            _musicTime2 -= Time.deltaTime;
            if (!_playerMusic[1].isPlaying && !_playerMusic[0].isPlaying)
            {
                _playerMusic[1].Play();
            }
            _playerMusic[1].volume += 2 * Time.deltaTime;
            if (_musicTime2 <= 0)
            {
                var speed = 1f * Time.deltaTime;
                camerascript.offset = Vector3.MoveTowards(camerascript.offset, _target, speed);
            }
        }
    }
    #endregion

    #region BackgroundImage
    [Header("---Background Manipulation---")]
    [SerializeField] private GameObject _BackGround;
    private Vector3 _bgImageOffset = new Vector3(-40f, -25f, -10f);
    private float _BGsmoothTime = 0.25f;
    private Vector3 _BGvelocity = Vector3.zero;

    //Repeating Background Stuff

    public GameObject[] levels;
    private Vector2 _screenBounds;

    private void MoveBackground()
    {
        Vector3 targetPosition = _Player.transform.position - _bgImageOffset;
        _BackGround.transform.position = Vector3.SmoothDamp(_BackGround.transform.position, targetPosition, ref _BGvelocity, _BGsmoothTime);
        if(_XInput != 0)
        {
            _bgImageOffset.x += 2.5f * _XInput * Time.deltaTime;
            //Debug.Log(_bgImageOffset.x);
        }
    }

    void LoadChildrenObjects(GameObject obj)
    {
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x;
        int childsNeeded = (int)Mathf.Ceil(_screenBounds.x * 2 / objectWidth);
        GameObject clone = Instantiate(obj) as GameObject;
        for(int i = 0; i <= childsNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }

        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());

        Debug.Log(obj.name);
    }

    private void RepositionChildrenObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if(children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x;
            if (_mainCamera.transform.position.x + _screenBounds.x > lastChild.transform.position.x + halfObjectWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            }
            else if (_mainCamera.transform.position.x - _screenBounds.x < firstChild.transform.position.x - halfObjectWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }
    #endregion

    ///
    /// Referances:
    ///     Background Tiling: https://www.youtube.com/watch?v=3UO-1suMbNc
    ///

}
