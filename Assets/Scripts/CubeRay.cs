using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRay : MonoBehaviour
{
    Ray cubeRayValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cubeRayValue = new Ray(transform.position, Vector3.forward);
        Physics.Raycast(cubeRayValue, 10f);
        Debug.DrawRay(transform.position, Vector3.forward * 10f, Color.green);
    }
}
