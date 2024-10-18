using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null) {
            player = GameObject.FindWithTag("Player").transform;
        }

        // offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        Vector3 target = player.position + offset;
        transform.position = target;
    }
}
