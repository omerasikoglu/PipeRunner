using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PipeRunner.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CameraControllerSettings _cameraSettings;
        [Space(20)] [SerializeField] private Transform _targetTransform;
        [SerializeField] private Transform _cameraTransform;

        private void Update()
        {
            CameraRotationFollow();
            CameraPositionFollow();
        }

        private void CameraRotationFollow()
        {
            _cameraTransform.rotation = Quaternion.Lerp(_cameraTransform.rotation,
                Quaternion.LookRotation(_targetTransform.position - _cameraTransform.position),
                Time.deltaTime * _cameraSettings.RotationLerpSpeed);
        }
        private void CameraPositionFollow()
        {
            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position,
                _targetTransform.position + _cameraSettings.PositionOffset, Time.deltaTime * _cameraSettings.PositionLerpSpeed);
        }
    } 
}
