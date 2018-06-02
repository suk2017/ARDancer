/***********************************
 
√浮现出现，有阴影
√滑条控制旋转，同时头发要甩起来
√滑条控制缩放，同时头发要甩起来
√看向镜头 但是超过一定程度就不看镜头（完全背对） 
√使用陀螺仪来进行看向镜头
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
using DG.Tweening;

public class DancerManager : MonoBehaviour
{
    public Transform camera;
    public Transform root;
    public Transform target;
    public Animator anim;
    public Transform Box;
    public Slider slider;
    public Slider slider2;
    public Text text;
    public Light directionalLight;
    public AudioSource audioSource;

    public static DancerManager current;//全场只有一个
    private static bool present = false;//是否已出场
    private static bool dancing = false;//当前是否在跳舞



    private void Awake()
    {
        current = this;//只记录最后一个初始化的
        directionalLight.shadowStrength = 0;
    }

    private void Update()
    {
        root.rotation = Quaternion.Euler(0, slider.value * 360f, 0);
        root.localScale = Vector3.one * (slider2.value * 2 + 0.3f);
        float result = Vector3.SqrMagnitude(camera.position);
        if (result < 30f && !dancing)
        {
            Dance();
        }
        else if (result > 30f && dancing)
        {
            Dance();
        }
    }

    /// <summary>
    /// 用于按钮
    /// </summary>

    public void Dance()
    {
        if (dancing)
        {
            //动画
            anim.SetBool("Dancing", false);

            //音乐
            audioSource.DOFade(0, 2f);

            //状态
            text.text = "停止跳舞";
            dancing = false;
        }
        else
        {
            //动画
            anim.SetBool("Dancing", true);

            //音乐
            audioSource.Stop();
            audioSource.DOFade(1, 2f);
            audioSource.Play();

            //状态
            text.text = "开始跳舞";
            dancing = true;
        }
    }

    /// <summary>
    /// 第一次出现
    /// </summary>
    public void Scene_Start()
    {
        if (!present)
        {
            current.Box.DOMoveY(-0.1f, 7f);
            current.Box.DOScaleY(0.1f, 7f);
            current.directionalLight.DOShadowStrength(1, 8f);
            present = true;
        }

    }
}
