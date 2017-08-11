﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class Lerp : MonoBehaviour
{
	[SerializeField]Vector3 startPosition;
	[SerializeField]Vector3 endPosition = Vector3.zero;
	[SerializeField]float t;
	IEnumerator myLerp;
	[SerializeField] int howfuther;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.L)) {
			myLerp = VectorLerp (startPosition, endPosition, t);
			StartCoroutine (routine: myLerp);
		}
	}

	void OnDrawGizmos ()
	{
		GizmosForVector.VisualizeLerp (startPosition, endPosition);
	}


	public IEnumerator VectorLerp (Vector3 startPosition, Vector3 endPosition, float time)
	{
		float lerpTime = time;
		float currentTime = 0;
		float percentage = 0;

		while (currentTime < time) {
			currentTime += Time.deltaTime;
			percentage = currentTime / time; 
			transform.position = Vector3.Lerp (a: startPosition, b: endPosition, t: percentage);
			yield return null;
		}
	}
}
