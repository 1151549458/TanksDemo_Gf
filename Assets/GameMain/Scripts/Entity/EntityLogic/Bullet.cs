using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFrameworkDemo;
using UnityGameFramework.Runtime;

namespace TanksDemo
{
    public class Bullet : EntityLogic
    {
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
        }
        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
        }

    }
}