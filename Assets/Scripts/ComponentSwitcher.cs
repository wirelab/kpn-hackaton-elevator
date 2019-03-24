using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uween;

public class ComponentSwitcher : MonoBehaviour
{
    public void Show(string name) {
        Debug.Log("Showing: " + name);
        //   GetComponent
        TweenSXYZ.Add(GameObject.Find(name), 0f, 1, 1, 1);
    }

    public void Hide(string name)
    {

        Debug.Log("Hiding: "+name);

        TweenSXYZ.Add(GameObject.Find(name), 0f, 0,0,0);
    }
}
