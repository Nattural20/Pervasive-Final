using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreenScript : MonoBehaviour
{
    //private Spr
    private Animator _anim;
    [SerializeField]private GameObject _exitButton;
    [SerializeField]private GameObject _messageBox;


    private void Start(){
        EventManager.goodChoice += GoodEndScreen;
        EventManager.badChoice += EndScreen;
        _anim = GetComponentInChildren<Animator>();
    }

    private void EndScreen()
    {
        _messageBox.GetComponent<TextMeshProUGUI>().text = "Please remeber me Gobi ... you were all I had left";
        StartCoroutine(GoodEnding());
    }

    private void GoodEndScreen()
    {
        Debug.Log("HI");
        _messageBox.GetComponent<TextMeshProUGUI>().text = "Thank You Gobi";
        StartCoroutine(GoodEnding());
    }

    private IEnumerator GoodEnding()
    {
        Debug.Log("HI");
        yield return new WaitForSeconds(2.0f);
        FadeToBlack();
        yield return new WaitForSeconds(5.0f);
        _exitButton.SetActive(true);
    }

    private void FadeToBlack()
    {
                Debug.Log("Animation Was called");
        _anim.Play("FadeToBlack");
    }

    public void ExitGame(){
        Debug.Log("Bye!");
        Application.Quit();
    }

}
