using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class MyVBHandler : MonoBehaviour,IVirtualButtonEventHandler
{

    private void Start()
    {
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            vbs[i].RegisterEventHandler(this);//把ImageTarget下所有含有VirtualButtonBehaviour组件的物体注册过来（使用前面写的Pressed和Released方法处理）。  
        }

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        //DancerManager.current.Dance();
        print("Pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        print("Released");
    }


}