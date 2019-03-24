using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uween;
using EZCameraShake;

public class moveElevator : MonoBehaviour
{
    public GameObject elevator;
    public float elavatorY = 0;
    public float liftHeight = 0;
    public int level = 0;
    public float watchTime;
    public bool lockCamera = false;

    bool isStarted = false;

    bool canReset = false;

    void Start()
    {
        
    }

    void addHeight(float height) {
        liftHeight = liftHeight + height;
    }
    void gotoHeight(float height) {
        liftHeight = height;
    }

    void Update()
    {
        if (!isStarted && (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0))) {
            isStarted = true;
            startCave();
        }

        if (canReset && (OVRInput.GetDown(OVRInput.RawButton.Back) || Input.GetMouseButtonDown(0))) {
            canReset = false;
            isStarted = false;

            gotoHeight(0);
            TweenY.Add(elevator, 0f, liftHeight);
        }
    }

    void startCave() {

        float watchTime = 25f;
        float platformRaiseTime = 8f;
        float delayForSpeech = 3f;

        // sound
        TweenNull.Add(elevator, delayForSpeech).Then(delegate ()
        {
            FindObjectOfType<AudioManager>().Play("narration01");
        });
        
        addHeight(12);
        TweenY.Add(elevator, platformRaiseTime, liftHeight).EaseInOutSine().Delay(watchTime).Then(startMuseum);
    }

    void startMuseum() {
        float watchTimeBeforeRotation = 5f;
        float rotateDuration = 20f;

        TweenRY.Add(elevator, rotateDuration, 360f).Delay(watchTimeBeforeRotation).EaseInSine().Then(delegate() {
            float watchTime = 1f;
            float platformRaiseTime = 1f;
            addHeight(6);
            TweenY.Add(elevator, platformRaiseTime, liftHeight).EaseInOutSine().Delay(watchTime).Then(startCity);
        });
    }

    void startCity()
    {
        float watchTime = 5f;
        float platformRaiseTime = 1f;
        addHeight(6);
        TweenY.Add(elevator, platformRaiseTime, liftHeight).EaseInOutSine().Delay(watchTime).Then(startMuseum);
    }

    void startFreefall() {
        float platformRaiseTime = 1f;
        addHeight(20);
        TweenY.Add(elevator, platformRaiseTime, liftHeight).EaseInOutSine().Then(delegate() {
            float freeFallTime = 2f;
            gotoHeight(18);

            TweenY.Add(elevator, freeFallTime, liftHeight).EaseInCubic().Then(delegate() {
                // shake floor
                CameraShaker.Instance.ShakeOnce(12, 2.5f, 0f, 2f);
                
                canReset = true;
            });
            TweenNull.Add(elevator, 0.5f).Then(delegate() {
                // free-fall shake
                CameraShaker.Instance.ShakeOnce(2f, 7f, freeFallTime, 0.01f);
            });
        });
    }
}
