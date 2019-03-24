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
        TweenRY.Add(engine1, 40f, 9200f).EaseInOutSine();
        TweenRY.Add(engine2, 40f, 9200f).EaseInOutSine();
        TweenRY.Add(engine3, 40f, 9200f).EaseInOutSine();
        TweenRY.Add(engine4, 40f, 9200f).EaseInOutSine();
    }

}
