using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PipeRunner.Player;

public class Intro : MonoBehaviour
{
    public Vector3 _localScale;
    public float _oran;

    private void Awake()
    {
        _localScale = transform.parent.transform.localScale * 0.5f;
        _oran = transform.parent.transform.localScale.x;
    }

    private void OnTriggerEnter(Collider collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            player.GetComponent<PlayerController>().SetTapScale(_localScale);
        }
    }
}
