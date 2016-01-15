using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CameraFollow))]
public class CameraFollowEditor : Editor
{

	public override void OnInspectorGUI ()
	{
		// Show the default inspector
		DrawDefaultInspector ();
		CameraFollow cf = (CameraFollow)target;
		
		if(GUILayout.Button("Set Min Camera Position"))
			cf.SetMinCamPosition();

		
		if(GUILayout.Button("Set Max Camera Position"))
			cf.SetMaxCamPosition();

	}
}
