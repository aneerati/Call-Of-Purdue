using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public Transform player;
    
    void Update()
    {
        Vector3 newPos = player.position;
        newPos.z = -10;
        transform.position = newPos;
    }
}
