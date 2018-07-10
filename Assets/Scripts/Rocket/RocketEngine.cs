using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RocketEngine : MonoBehaviour
{
    [SerializeField] private float _delay = 5f;
    [SerializeField] private float _duration = 5f;
    [SerializeField] private float _startVelocity = 0;
    [SerializeField] private float _forceMultiplier = 10;
    [SerializeField] private AnimationCurve _force;
    [SerializeField] private Vector3 _enginePosition = new Vector3(0, 0, 0);
    [SerializeField] private bool _looping = false;
    [SerializeField] private bool _lockOnEndForce = false;

    private Rigidbody _rigidbody;
    private float _forceNow;
    private float _engineIsWorkingTime;
    private float _workEndEngineTime;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.forward * _startVelocity;
        _engineIsWorkingTime = -_delay;
        _workEndEngineTime = _force[_force.length - 1].time * _duration;
    }

    private void Update()
    {
        _engineIsWorkingTime += Time.deltaTime;

        if (_engineIsWorkingTime >= 0 && (_engineIsWorkingTime <= _workEndEngineTime || _looping))
        {
            _forceNow = _force.Evaluate(_engineIsWorkingTime % _workEndEngineTime);
        }
        else if (!_lockOnEndForce)
        {
            _forceNow = 0;
        }
    }

    void FixedUpdate()
    {
        _rigidbody.AddForceAtPosition(transform.forward * _forceNow * _forceMultiplier,
        transform.position + _enginePosition, ForceMode.Force);
    }
}