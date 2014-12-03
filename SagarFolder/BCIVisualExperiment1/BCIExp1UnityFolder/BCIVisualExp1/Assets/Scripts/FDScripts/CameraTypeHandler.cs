﻿using UnityEngine;
using System.Collections;
using InControl;


public class CameraTypeHandler : MonoBehaviour 
{

	public GameObject normalCameraObject;
	public GameObject ovrCameraControllerObject;

	public Transform lookAtTarget;
	public bool isOVR = false;
	public float ovrFOV = 120.0f;

	Transform meshCreatureTransform;

	// Use this for initialization
	void Start () 
	{
		normalCameraObject.SetActive(!isOVR);
		ovrCameraControllerObject.SetActive(isOVR);

		ovrCameraControllerObject.GetComponent<OVRCameraController>().SetVerticalFOV(ovrFOV);

		ovrCameraControllerObject.transform.GetChild(0).camera.fieldOfView = ovrFOV;
		ovrCameraControllerObject.transform.GetChild(1).camera.fieldOfView = ovrFOV;

		meshCreatureTransform = GameObject.FindGameObjectWithTag("MeshCreature").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{

		var inputDevice = InputManager.ActiveDevice;		

		if(inputDevice.LeftBumper.WasPressed)
		{
			isOVR = !isOVR;
			
			normalCameraObject.SetActive(!isOVR);
			ovrCameraControllerObject.SetActive(isOVR);

		}

		normalCameraObject.transform.LookAt(lookAtTarget, meshCreatureTransform.up);
		ovrCameraControllerObject.transform.LookAt(lookAtTarget, meshCreatureTransform.up);
	
	}
}
