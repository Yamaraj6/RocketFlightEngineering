using Extensions;
using UnityEngine;

namespace Rocket
{
    [RequireComponent(typeof(Rigidbody))]
    public class RocketEngine : MonoBehaviour
    {
        [SerializeField] public Vector3 EnginePosition = new Vector3(0, 0, 0);
        [SerializeField] public float ForceMultiplier = 10;
        [SerializeField] public AnimationCurve Force;
        [SerializeField] public float Duration = 4f;

        [SerializeField] private float _delay = 3f;
        [SerializeField] private float _startVelocity = 0;
        [SerializeField] private bool _looping = false;
        [SerializeField] private bool _lockOnEndForce = false;
         
        private Rigidbody _rigidbody;
        private float _forceNow;
        private float _engineIsWorkingTime;
        private float _workEndEngineTime;

        private bool _readyToStart = false;

        public void PrepareToStart()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.velocity = transform.forward * _startVelocity;
            _engineIsWorkingTime = -_delay;
            _workEndEngineTime = Force[Force.length - 1].time * Duration;
            transform.SetActiveAllChildren(true);
            _readyToStart = true;
        }

        private void Update()
        {
            if (!_readyToStart)
                return;
            _engineIsWorkingTime += Time.deltaTime;

            if (_engineIsWorkingTime >= 0 && (_engineIsWorkingTime <= _workEndEngineTime || _looping))
            {
                _forceNow = Force.Evaluate(_engineIsWorkingTime % _workEndEngineTime);
            }
            else if (!_lockOnEndForce)
            {
                _forceNow = 0;
            }
        }

        private void FixedUpdate()
        {
            if (!_readyToStart)
                return;

            _rigidbody.AddForceAtPosition(transform.forward * _forceNow * ForceMultiplier,
                transform.position + EnginePosition, ForceMode.Force);
        }
    }
}