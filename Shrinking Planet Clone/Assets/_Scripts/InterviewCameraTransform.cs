using System;
using UnityEngine;

[Serializable]
public struct InterviewCameraTransform
{
    [field: SerializeField] public Vector3 CameraPosition { get; private set; }
    [field: SerializeField] public Quaternion CameraRotation { get; private set; }
}
