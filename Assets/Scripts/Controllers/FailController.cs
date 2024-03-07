using System;
using NecatiAkpinar.Abstractions;
using NecatiAkpinar.Managers;
using UnityEngine;

namespace NecatiAkpinar.Controllers
{
    public class FailController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var ball = other.GetComponent<BaseBall>();
            if (ball != null)
                EventManager.OnBallDropped?.Invoke();
        }
    }
}