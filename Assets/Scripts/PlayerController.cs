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

        private Rigidbody _rigidbody;

        private const float _movementSpeed = 1f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            //Move();
        }
        private void FixedUpdate()
        {
            MoveRigidbody();
        }
        private void OnTriggerEnter(Collider collision)
        {
            Obstacle obstacle = collision.GetComponent<Obstacle>();

            if (obstacle != null)
            {
                //Destroy(gameObject);
            }
        }
        private void MoveRigidbody()
        {
            _rigidbody.MovePosition(transform.position + Vector3.up * Time.deltaTime * _movementSpeed);
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
