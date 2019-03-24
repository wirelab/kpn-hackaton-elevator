using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uween;
using EZCameraShake;

public class moveElevator : MonoBehaviour
{
    public GameObject elevator;
    public GameObject camera01;
    public float elavatorY = 0;
    public float nextLevelHeight = 0;
    public int level = 0;
    public float watchTime;
    public bool lockCamera = false;

    float freeFallTime = 2f;

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
            watchTime = 0.5f;
            nextLevelHeight = 20;
        }

        elavatorY = elavatorY + nextLevelHeight;

        // the end
        if (level == 3) {
            TweenY.Add(elevator, 0.1f, elavatorY).EaseInOutSine().Delay(watchTime).Then(GoFreeFall);
            return;
        }

        TweenY.Add(elevator, 0.1f, elavatorY).EaseInOutSine().Delay(watchTime).Then(goToNextFloor);

    }

    void GoFreeFall() {
        // Debug.Log("i am freefallin;");
        float delay = 1f;
        TweenY.Add(elevator, freeFallTime, 18).EaseInCubic().Delay(delay).Then(ShakeFloor);
        TweenNull.Add(elevator, delay + 0.5f).Then(ShakeFreeFall);
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
    void ShakeFreeFall() {
        CameraShaker.Instance.ShakeOnce(2f, 7f, freeFallTime, 0.01f);
    }
    void ShakeFloor() {
        CameraShaker.Instance.ShakeOnce(12, 2.5f, 0f, 2f);
    }

}
