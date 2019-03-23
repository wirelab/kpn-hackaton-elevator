using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uween;

public class moveElevator : MonoBehaviour
{
    public GameObject elevator;
    public GameObject camera01;
    public float elavatorY = 0;
    public float nextLevelHeight = 0;
    public int level = 0;
    public float watchTime;
    public bool lockCamera = false;

    void Start()
    {
        goToNextFloor();
    }

    void goToNextFloor() {
        level++;

        if (level == 1) {
            watchTime = 5f;
          
            nextLevelHeight = 12;            
        }

        if (level == 2) {
            watchTime = 5f;
            rotatePlatform();
            nextLevelHeight = 6;            
        }
        if (level == 3) {
            watchTime = 5f;
            nextLevelHeight = 20;            
        }

        elavatorY = elavatorY + nextLevelHeight;

        // the end
        if (level == 3) {
            TweenY.Add(elevator, 4f, elavatorY).EaseInOutSine().Delay(watchTime).Then(GoFreeFall);
            return;
        }

        TweenY.Add(elevator, 4f, elavatorY).EaseInOutSine().Delay(watchTime).Then(goToNextFloor);

    }

    void GoFreeFall() {

        // Debug.Log("i am freefallin;");
        TweenY.Add(elevator, 2f, 18).EaseInCubic().Delay(5f);
    }

    void rotatePlatform()
    {
        // Debug.Log("Platform is rotating;");
        // lockCamera = true;
        // TweenRY.Add(elevator, 5f, 360f).EaseInSine();
        // camera01.transform.LookAt(target);

    }

    void Update()
    {
    
    }

}
