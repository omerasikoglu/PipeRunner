using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PipeRunner.PlayerInput
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private InputManagerData _inputManagerData;
        [Space(20)]
        [SerializeField] private KeyCode _tapButton;

        private void Update()
        {
            _inputManagerData.isTap = Input.GetKeyDown(_tapButton);
        }
    } 
}
