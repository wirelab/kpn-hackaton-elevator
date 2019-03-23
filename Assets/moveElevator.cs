using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uween;

public class moveElevator : MonoBehaviour
{

    public GameObject elevator;
    public float elavatorY = 0;

    void Start()
    {
       
        NextFloor();
    }

    void NextFloor() {
        Debug.Log("we are moving to the next floor");
        elavatorY = elavatorY + 6;
        TweenY.Add(elevator, 4f, elavatorY).EaseInOutSine().Delay(5f).Then(NextFloor);
    }

}
