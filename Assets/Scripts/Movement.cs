using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody cubeRB;
    public float moveSpeed;

    private Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCube();
    }

    public void MoveCube()
    {
        cubeRB.velocity = new Vector3(joystick.Direction.x, 0, joystick.Direction.y) * moveSpeed;
    }
}
