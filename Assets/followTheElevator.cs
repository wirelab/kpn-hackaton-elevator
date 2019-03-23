using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTheElevator : MonoBehaviour
{
    public Vector3 myPos;
    public Vector3 additionalHeight;
    public Transform myPlay;
    
    public void Update()
    {
        transform.position = myPlay.position + (myPos + additionalHeight);
    }

}
