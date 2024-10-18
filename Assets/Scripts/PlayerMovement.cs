using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody player;

    public float forwardSpeed = 5.0f;
    public float switchSpeed = 10.0f;

    private int lane = 0;
    private float[] lanePositions = { -4.5f, -1.5f, 1.5f, 4.5f }; 
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        target = new Vector3(lanePositions[lane], transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (lane > 0) {
                lane--;
                Debug.Log("Lane: " + lane);
                target = new Vector3(lanePositions[lane], transform.position.y, transform.position.z);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (lane < lanePositions.Length - 1) {
                lane++;
                Debug.Log("Lane: " + lane);
                target = new Vector3(lanePositions[lane], transform.position.y, transform.position.z);
            }
        }

        Vector3 newPosition = new Vector3(target.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, switchSpeed * Time.deltaTime);
    }
}
