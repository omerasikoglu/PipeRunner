using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PipeRunner
{
    public class Corn : MonoBehaviour
    {
        public float cubeSize = 0.2f;
        public int cubesInRow = 5;

        private float cubesPivotDistance;
        private Vector3 cubesPivot;

        public float explosionForce = 50f;
        public float explosionRadius = 4f;
        public float explosionUpward = 0.4f;

        private float _cornScale = 1f;

        public Corn(float cornScale)
        {
            _cornScale = cornScale;
        }

        // Use this for initialization
        private void Start()
        {
            //adjust local scale
            //transform.localScale = new Vector3(_cornScale * .5f , .8f , _cornScale * .5f);

            //calculate pivot distance
            cubesPivotDistance = cubeSize * cubesInRow / 2;
            //use this value to create pivot vector)
            cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Player")
            {
                Explode();
                Destroy(gameObject);
            }
        }

        public void Explode()
        {
            //make object disappear
            gameObject.SetActive(false);

            //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
            for (int x = 0; x < cubesInRow; x++)
            {
                for (int y = 0; y < cubesInRow; y++)
                {
                    for (int z = 0; z < cubesInRow; z++)
                    {
                        CreatePiece(x, y, z);
                    }
                }
            }

            //get explosion position
            Vector3 explosionPos = transform.position;
            //get colliders in that position and radius
            Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
            //add explosion force to all colliders in that overlap sphere
            foreach (Collider hit in colliders)
            {
                //get rigidbody from collider object
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    //add explosion force to this body with given parameters
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
                }
            }
        }
        private void CreatePiece(int x, int y, int z)
        {
            //create piece
            GameObject piece;
            piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

            //set piece position and scale
            piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
            piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

            //add rigidbody and set mass
            piece.AddComponent<Rigidbody>();
            piece.GetComponent<Rigidbody>().mass = cubeSize;
        }
    }
}