using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uween;

public class moveElevator : MonoBehaviour
{

    public GameObject elevator;
    void Update()
    {
        // transform.Translate(Vector3.forward * (Time.deltaTime / 3));

        // log timeframe        
        TweenY.Add(elevator, 5f, 10f);
        // Debug.Log(Time.deltaTime);
    }
}
