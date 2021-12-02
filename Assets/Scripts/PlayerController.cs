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
        private Vector3 tapScale = new Vector3(.5f, 1f, .5f); // ilk tikladigimizda

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            //Move();
            transform.localScale = _inputManagerData.isTap ? GetTapScale() : Vector3.one;
        }
        private void FixedUpdate()
        {
            MoveRigidbody();
        }
        private Vector3 GetTapScale()
        {
            return tapScale;
        }
        public void SetTapScale(Vector3 localPos)
        {
            tapScale = localPos;
        }
        private void OnTriggerEnter(Collider collision)
        {
            Obstacle obstacle = collision.GetComponent<Obstacle>();

            if (obstacle != null)
            {
                //Destroy(gameObject);
            }

            Corn corn = collision.GetComponent<Corn>();
            if (corn!=null)
            {
                Debug.Log("corn");
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
