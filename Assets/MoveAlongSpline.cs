using UnityEngine;
using System.Collections;

public class MoveAlongSpline : MonoBehaviour {
	public SplineComponent splineComponent;

	public float currentPosition = 0;
	public float speed = 1.0f;

	public float currentSpeed = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 oldPos = transform.position;
		var splineCurve = splineComponent.GetSplineObject();
		Vector3 currentCurveVelocity = splineCurve.GetVelocity(currentPosition);
		currentPosition += Time.deltaTime*speed / currentCurveVelocity.magnitude;
		if (currentPosition > splineCurve.totalTime){
			currentPosition = 0;
		}
		transform.position = splineCurve.GetPosition(currentPosition);
		currentSpeed = (transform.position - oldPos).magnitude / Time.deltaTime;
	}
}
