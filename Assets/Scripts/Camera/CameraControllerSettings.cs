using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PipeRunner.Camera
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Camera/Settings")]

    public class CameraControllerSettings : ScriptableObject
    {
        [SerializeField] private float _rotationLerpSpeed;
        [SerializeField] private float _positionLerpSpeed;

        [SerializeField] private Vector3 _positionOffset;

        public float RotationLerpSpeed { get { return _rotationLerpSpeed; } }
        public float PositionLerpSpeed { get { return _positionLerpSpeed; } }
        public Vector3 PositionOffset { get { return _positionOffset; } }
    } 
}
