using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

namespace Hamish
{
    public class BackgroundScript : MonoBehaviour
    {
        private Vector3 offset = new Vector3(-220f, -140f, -160f); //This is so badly writen, but it's fine
        private float smoothTime = 0.25f;
        private Vector3 velocity = Vector3.zero;
        [SerializeField] private Transform target;
        private Vector3 lastPosition;

        private void Start()
        {
            lastPosition = target.position;
        }

        // Update is called once per frame
        void Update()
        {

            if (lastPosition != target.position)
            {
                offset.x += target.position.x - lastPosition.x;
            }

            Vector3 targetPosition = target.position - offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            lastPosition = target.position;
        }
    }

}