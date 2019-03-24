using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uween;
using EZCameraShake;

public class moveElevator : MonoBehaviour
{
    public GameObject elevator;
    public GameObject soundObject;
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
            // TweenY.Add(elevator, 0f, 0).Then(startCave);
            // TweenY.Add(elevator, 0f, 12).Then(startMuseum);
            TweenY.Add(elevator, 0f, 18).Then(startCity);
        }

        if (canReset && (OVRInput.GetDown(OVRInput.RawButton.Back) || Input.GetMouseButtonDown(0))) {
            canReset = false;
            isStarted = false;

            gotoHeight(0);
            TweenY.Add(elevator, 0f, liftHeight);
        }
    }

    void startCave() {

        float platformRaiseTime = 10f;
        float delayForSpeech = 1f;
        float watchTime = 18.3f + delayForSpeech;

        // sound
        TweenNull.Add(soundObject, delayForSpeech).Then(delegate () {
            FindObjectOfType<AudioManager>().Play("narration-cave");
        });
        
        gotoHeight(12);
        TweenY.Add(elevator, platformRaiseTime, liftHeight).EaseInOutSine().Delay(watchTime).Then(startMuseum);
    }

    void startMuseum() {
        float watchTimeBeforeRotation = .5f;
        float rotateDuration = 33f;

        FindObjectOfType<AudioManager>().Play("narration-museum");

        TweenRY.Add(elevator, rotateDuration, 100f).Delay(watchTimeBeforeRotation).Then(delegate() {
            float watchTime = 1f;
            float platformRaiseTime = 1f;
            gotoHeight(18);
            TweenY.Add(elevator, platformRaiseTime, liftHeight).EaseInOutSine().Delay(watchTime).Then(startCity);
        });
    }

    void startCity()
    {
        float watchTime = 5f;
        float platformRaiseTime = 15f;
        gotoHeight(38);

        FindObjectOfType<AudioManager>().Play("narration-city");
        TweenY.Add(elevator, platformRaiseTime, liftHeight).EaseInOutSine().Delay(watchTime).Then(startFreefall);
    }

    void startFreefall() {
        float freeFallTime = 2f;
        gotoHeight(18);

        FindObjectOfType<ComponentSwitcher>().Show("Line018");

        FindObjectOfType<AudioManager>().Stop("narration-city");
        FindObjectOfType<AudioManager>().Play("free-fall");

        TweenY.Add(elevator, freeFallTime, liftHeight).EaseInCubic().Then(delegate() {

            FindObjectOfType<AudioManager>().Stop("free-fall");
            FindObjectOfType<AudioManager>().Play("free-fall-crash");

            TweenNull.Add(soundObject, 2.5f).Then(delegate () {
                FindObjectOfType<AudioManager>().Play("narration-future");
            });

            // shake floor
            CameraShaker.Instance.ShakeOnce(12, 2.5f, 0f, 2f);
            
            canReset = true;
        });
        TweenNull.Add(elevator, 0.5f).Then(delegate() {
            // free-fall shake
            CameraShaker.Instance.ShakeOnce(2f, 7f, freeFallTime, 0.01f);
        });
    }
}
