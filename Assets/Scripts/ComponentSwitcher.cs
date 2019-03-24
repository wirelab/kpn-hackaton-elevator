using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uween;

public class ComponentSwitcher : MonoBehaviour
{

    public GameObject cable;
    public void Show() {
        //   GetComponent
        TweenSXYZ.Add(cable, 0f, 1, 1, 1);
    }

    public void Hide()
    {
       TweenSXYZ.Add(cable, 0f, 0,0,0);
    }
}
