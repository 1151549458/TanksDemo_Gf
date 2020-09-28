/**
 *Copyright(C) 2018 by DefaultCompany
 *All rights reserved.
 *FileName:     EnemyTanks.cs
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
namespace TanksDemo {
    public class EnemtyTanks :BaseTanks
    {
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            tanksColor = new Color(229.0f/255.0f, 46.0f/ 255.0f, 40.0f / 255.0f, 1);
            Debug.Log(tanksColor);
            SetTanksColor(tanksColor);

        }
    }
}