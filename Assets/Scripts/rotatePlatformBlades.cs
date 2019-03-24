using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uween;


public class rotatePlatformBlades : MonoBehaviour
{

    public GameObject engine1;
    public GameObject engine2;
    public GameObject engine3;
    public GameObject engine4;
    // Start is called before the first frame update
    void Start()
    {
        rotateBlades();
    }

    // Update is called once per frame
    void rotateBlades()
    {
        // Debug.Log("Rotate the blades now");
        // TweenRY.Add(engine1, 40f, 9200f);
        // TweenRY.Add(engine2, 40f, 9200f);
        // TweenRY.Add(engine3, 40f, 9200f);
        // TweenRY.Add(engine4, 40f, 9200f);

        startTween(engine1);
        startTween(engine2);
        startTween(engine3);
        startTween(engine4);
    }

    void startTween(GameObject engine) {
        TweenRY.Add(engine, 1f, 360f).Then(delegate() {
            startTween(engine);
        });
    }

}
