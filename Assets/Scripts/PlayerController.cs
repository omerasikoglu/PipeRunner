using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PipeRunner.PlayerInput;
using System;

namespace PipeRunner.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputManagerData _inputManagerData;

        private const float _movementSpeed = 10f;


        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (Time.timeScale != 0)
            {
                transform.Translate(Vector3.up * Time.deltaTime);
            }
        }
    } 
}
