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
namespace TanksDemo
{
    public class PlayerTanks : BaseTanks
    {
        protected override void Awake()
        {
            base.Awake();


        }

        public override void InitTanks(CampType t, TanksInfo info)
        {
            base.InitTanks(t, info);

        }

        public override void SetControlStep(bool b)
        {
            base.SetControlStep(b);
        }

        public override void SetLevel(int index)
        {
            base.SetLevel(index);


        }

        public override void SetTanksColor(Color color)
        {
            base.SetTanksColor(color);
        }


        public override void Reset()
        {
            base.Reset();
        }
    }
}