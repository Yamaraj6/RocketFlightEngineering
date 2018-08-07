using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private Transform _target;
	[SerializeField] private float _smoothSpeed = 0.125f;
	[SerializeField] private Vector3 _offset;


	private void FixedUpdate()
	{
		Follow();
	}	

	private void Follow()
	{
		if (_target == null)
		{
			Debug.LogWarning("Target doesn't exist!");
			return;
		}
		
		var desiredPoint = _target.position + _offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPoint, _smoothSpeed);
		transform.position = smoothedPosition;
		transform.LookAt(_target);
	}
}
