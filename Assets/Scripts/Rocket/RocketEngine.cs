using System;
using System.ComponentModel;
using DataContainer;
using Engine;
using Extensions;
using Models;
using PlayerManager;
using UnityEngine;

namespace Rocket
{
    [RequireComponent(typeof(Rigidbody))]
    public class RocketEngine : MonoBehaviour
    {
        public EngineNumber EngineNumber;
        [SerializeField] public float ForceMultiplier;

        [SerializeField] public Vector3 EnginePosition = new Vector3(0, 0, 0);
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

        private void Start()
        {
            CountStartVariables();

            SetStartValues();
        }

        private void CountStartVariables()
        {
            _rigidbody = GetComponentInParent<Rigidbody>();
            _rigidbody.velocity = transform.forward * _startVelocity;
            _engineIsWorkingTime = -_delay;
            _workEndEngineTime = Force[Force.length - 1].time * Duration;
        }

        private void SetStartValues()
        {
            ForceMultiplier = new EnginePowerProvider().ProvidePower(EngineNumber);
        }

        public void PrepareToStart()
        {
            UnitOfWork.PointNumber = "1";
            ForceMultiplier = new EnginePowerProvider().ProvidePower(EngineNumber);
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