﻿/* MIT License
Copyright (c) 2017 Uvi Vagabond, UnityBerserkers
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class SlerpTest : MonoBehaviour
{
	[Header ("SHOWING TRAJECTORY OF ROTATION")][Space (11)]

	[Header ("Origin of vectors")]
	[SerializeField]Vector3 origin = Vector3.zero;
	[Header ("Quaternions in form of euler angle")]
	[SerializeField]Vector3 start = Vector3.right;
	[SerializeField]Vector3 end = Vector3.up;

	[Space (22)][Header ("Which version of method")]
	[SerializeField] bool useBuiltinDirection;
	[Space (5)][SerializeField]BaseVectorDirection builtinDirection;
	[SerializeField]Vector3 customDirectionn = Vector3.right;

	void Update ()
	{
		// when we press O we start slerping cube
		if (Input.GetKeyDown (KeyCode.O)) {
			Quaternion startQ = Quaternion.Euler (start);
			Quaternion endQ =	Quaternion.Euler (end);
			IEnumerator slerp = QuaternionCoroutines.Slerp (transform, startQ, endQ, 5);
			StartCoroutine (slerp);
		}
		// when we press P when you want to set cube to start rotation
		if (Input.GetKeyDown (KeyCode.P)) {
			transform.rotation = Quaternion.Euler (start);	
		}
	}

	void OnDrawGizmos ()
	{
		Quaternion startQ = Quaternion.Euler (start);
		Quaternion endQ = Quaternion.Euler (end);
		if (useBuiltinDirection) {
			GizmosForQuaternion.Slerp (origin, startQ, endQ, builtinDirection, 6f);
		} else {
			GizmosForQuaternion.Slerp (origin, startQ, endQ, customDirectionn, 6f);
		}
	}


}
