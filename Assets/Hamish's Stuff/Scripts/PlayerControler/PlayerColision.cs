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

    private void OnTriggerStay(Collider other)
    {
        switch (other.tag){
            case "Marvel":
                GameManager.Instance.ScenicTrigger(true);
                break;
            default:
                GameManager.Instance.ScenicTrigger(false);
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameManager.Instance.ScenicTrigger(false);
    }
}
