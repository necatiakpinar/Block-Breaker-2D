using System;
using System.Collections;
using System.Collections.Generic;
using NecatiAkpinar.Data.GameElementData;
using NecatiAkpinar.Managers;
using UnityEngine;

namespace NecatiAkpinar.Abstractions
{
    public abstract class BasePaddle : MonoBehaviour
    {
        [SerializeField] private SO_BasePaddleData _data;

        public SO_BasePaddleData Data => _data;

        private void OnEnable()
        {
            EventManager.GetPaddle += () => (this);
        }

        private void OnDisable()
        {
            EventManager.GetPaddle -= () => (this);
        }
    }
}