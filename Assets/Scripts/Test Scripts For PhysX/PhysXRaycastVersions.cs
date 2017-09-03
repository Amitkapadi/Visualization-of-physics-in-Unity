﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class PhysXRaycastVersions : MonoBehaviour
{

	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 direction;

	[SerializeField]float maxDistance = 1;

	void Update ()
	{
		#region Filtering colliders
		RaycastHit hitInfo;
		bool isSomethingHit = Physics.Raycast (origin: origin, direction: direction, hitInfo: out hitInfo, maxDistance: maxDistance,

			                      layerMask: Physics.DefaultRaycastLayers, queryTriggerInteraction: QueryTriggerInteraction.UseGlobal);



		RaycastHit[] hitInfos = new RaycastHit[3];
		int hitCollidersCount = Physics.RaycastNonAlloc (origin: origin, direction: direction, results: hitInfos);
		#endregion


		
		#region Number of returned elements
//		RaycastHit hitInfo;
//		bool isSomethingHit = Physics.Raycast (origin: origin, direction: direction, hitInfo: out hitInfo, maxDistance: maxDistance);
//		RaycastHit[] hitInfos = Physics.RaycastAll (origin: origin, direction: direction, maxDistance: maxDistance);
//
//		RaycastHit[] hitInfos2 = new RaycastHit [2];
//		int hitCollidersCount = Physics.RaycastNonAlloc (origin: origin, direction: direction, results: hitInfos2, maxDistance: maxDistance);
		#endregion


	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.DrawRaycast (origin: origin, direction: direction, maxDistance: maxDistance);
		//		GizmosForPhysics3D.DrawRaycast (ray: ray, maxDistance: maxDistance);
	}
}
