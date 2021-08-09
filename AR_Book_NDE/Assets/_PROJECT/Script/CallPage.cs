using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPage : MonoBehaviour
{

    public void OpenUrl()
    {
        Application.OpenURL( "tel://5555551212" );
    }
    
}
