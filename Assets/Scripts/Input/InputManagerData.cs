using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PipeRunner.PlayerInput
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Input/Data")]
    public class InputManagerData : ScriptableObject
    {
        public bool isTap; //ekrana dokundu mu
    }

}