using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLoop : MonoBehaviour
{
     public iTween.EaseType easeType;
     public iTween.LoopType loopType;

     void Start()
     {
         iTween.RotateTo(this.gameObject, iTween.Hash("z", 200, "time", 1.5f, "easetype", easeType, "looptype", loopType));
     }

    // void Update()
    // {
    //     transform.Rotate(new Vector3(0f, 0f, 1f));
    // }
}
