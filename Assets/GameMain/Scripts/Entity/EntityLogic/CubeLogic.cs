/**
 *Copyright(C) 2018 by DefaultCompany
 *All rights reserved.
 *FileName:     CubeLogic.cs
 *Author:       Pan
 *Version:      1.0
 *UnityVersion��2018.4.0f1
 *Date:         2020-08-13
 *Description:   
 *History:
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameFrameworkDemo
{
    public class CubeLogic : EntityLogic
    {
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            Log.Info("显示一个cube" + Name);
        }
        protected override void OnRecycle()
        {
            base.OnRecycle();
        }
        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
        }
    }
}