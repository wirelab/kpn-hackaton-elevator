using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uween;

public class moveElevator : MonoBehaviour
{

    public GameObject elevator;
    public float elavatorY = 0;
    public float levelHeight = 0;
    public int level = 0;

    void Start()
    {
       
        NextFloor();
    }

    void NextFloor() {
        Debug.Log("we are moving to the next floor");
        level++;
        

        if (level == 1) levelHeight = 12;
        if (level == 2) levelHeight = 6;
        if (level == 3) levelHeight = 20;
        Debug.Log(level);
        Debug.Log(levelHeight);

   
        elavatorY = elavatorY + levelHeight;

        if (level == 3) {
            TweenY.Add(elevator, 4f, elavatorY).EaseInOutSine().Delay(5f).Then(FreeFall);
            return;
        }
        TweenY.Add(elevator, 4f, elavatorY).EaseInOutSine().Delay(5f).Then(NextFloor);

    }

    void FreeFall() {

        Debug.Log("i am freefallin;");
        TweenY.Add(elevator, 2f, 18).EaseInExponential().Delay(5f);
    }

}
