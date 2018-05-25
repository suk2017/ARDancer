/***********************************
 
浮现出现，有阴影
滑条控制旋转，同时头发要甩起来
滑条控制缩放，同时头发要甩起来
看向镜头 但是超过一定程度就不看镜头（完全背对） 
使用陀螺仪来进行看向镜头
使用声音来识别（开始/停止/转）

观众席出现 就跳舞

看镜头 不看镜头 看镜头
站立   跳舞     站立

16周交

 ***********************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DancerManager : MonoBehaviour
{

    public Transform target;

    public Slider slider;


    private void Update()
    {
        target.rotation = Quaternion.Euler(0, slider.value * 360f, 0);
    }
}
