using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hamish
{
    public class PlayerColision : MonoBehaviour
    {
        private Collider _tColider;

        private bool canChoose;
        // Start is called before the first frame update
        void Start()
        {
            canChoose = false;
            _tColider = GetComponent<BoxCollider>();
            GameManager.theChoice += CanChoose;
        }

        private void CanChoose()
        {
            canChoose = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            switch (other.tag)
            {
                case "Marvel":
                    EventManager.EnteredArea(other.tag);
                    //GameManager.Instance.ScenicTrigger(true);
                    break;
                case "Aversion":
                    EventManager.EnteredArea(other.tag);
                    Debug.Log("AI Won't Like this");
                    break;
                case "Dead":
                    EventManager.SofviHasDied();
                    canChoose = true;
                    Destroy(other);
                    break;
                case "Good":
                    if(canChoose){
                        EventManager.EnteredArea("Good");
                    }
                    break;
                case "Bad":
                    if(canChoose){
                        EventManager.EnteredArea("Bad");
                    }
                    break;
                default:
                    //GameManager.Instance.ScenicTrigger(false);
                    break;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Marvel")
            {
                Destroy(other);
            }
            //GameManager.Instance.ScenicTrigger(false);
            EventManager.ExitArea(other.tag);
        }
    } 
}
