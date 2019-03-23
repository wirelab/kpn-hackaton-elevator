using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uween;

public class moveElevator : MonoBehaviour
{
    public GameObject elevator;
    public float elavatorY = 0;
    public float nextLevelHeight = 0;
    public int level = 0;
    public float watchTime;

    void Start()
    {
        goToNextFloor();
    }

    void goToNextFloor() {
        level++;

        if (level == 1) {
            watchTime = 5f;
            rotatePlatform();
            nextLevelHeight = 12;            
        }

        if (level == 2) {
            watchTime = 5f;
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

        Debug.Log("i am freefallin;");
        TweenY.Add(elevator, 3f, 18).EaseInCubic().Delay(5f);
    }

    void rotatePlatform()
    {
        TweenRY.Add(elevator, 20f, 360f).EaseInSine();
        Debug.Log("Platform is rotating;");
    }

}
