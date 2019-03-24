using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentSwitcher : MonoBehaviour
{

     public GameObject obj;

    public void Show(string name) {
        //   GetComponent
        obj = GameObject.Find(name);
        obj.SetActive(true);
    }

    public void Hide(string name)
    {
        //   GetComponent
        obj = GameObject.Find(name);
        obj.SetActive(false);
    }
}
