using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    private Collider _tColider;
    // Start is called before the first frame update
    void Start()
    {
        _tColider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag){
            case "Marvel":
                EventManager.EnteredArea(other.tag);
                GameManager.Instance.ScenicTrigger(true);
                break;
            case "Aversion":
                EventManager.EnteredArea(other.tag);
                Debug.Log("AI Won't Like this");
                break;
            default:
                GameManager.Instance.ScenicTrigger(false);
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Marvel")
        {
            Destroy(other);
        }
        GameManager.Instance.ScenicTrigger(false);
        EventManager.ExitArea(other.tag);
    }
}
