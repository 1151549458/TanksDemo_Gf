/**
 *Copyright(C) 2018 by DefaultCompany
 *All rights reserved.
 *FileName:     PlayerTanks.cs
 *Author:       Pan
 *Version:      1.0
 *UnityVersion��2018.4.0f1
 *Date:         2020-09-11
 *Description:   
 *History:
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFrameworkDemo;
namespace TanksDemo
{
    public class PlayerTanks : BaseTanks
    { 
        public override void SetControlStep(bool b)
        {
            base.SetControlStep(b);
        }

        public override void SetLevel(int index)
        {
            base.SetLevel(index);


        }
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            tanksColor = Color.red;
            SetTanksColor(tanksColor);
        }
        protected override void OnDeath()
        {
            base.OnDeath();

        
             
        }

  
        public override void Reset()
        {
            base.Reset();
        }
    }
}