using System;
using System.Collections;
using UnityEngine;

namespace KalkuzSystems.Gameplay
{
    public abstract class CameraShakerBase : MonoBehaviour
    {
        [SerializeField] protected Camera cam;
        [SerializeField] protected bool fetchMainCameraOnAwake = true;
        
        [SerializeField] protected float shakeDuration = 1f;
        [SerializeField] protected float shakeMagnitude = 0.7f;
        
        protected Coroutine shakeCoroutine;

        private void Awake()
        {
            if (fetchMainCameraOnAwake) cam = Camera.main;
        }

        public void Bound(Camera camera)
        {
            cam = camera;
        }

        public void Shake(float duration, float magnitude)
        {
            shakeDuration = duration;
            shakeMagnitude = magnitude;
            Shake();
        }
        
        public void Shake()
        {
            if (shakeCoroutine != null) StopCoroutine(shakeCoroutine);
            shakeCoroutine = StartCoroutine(ShakeCoroutine());
        }
        
        protected abstract IEnumerator ShakeCoroutine();
    }
}