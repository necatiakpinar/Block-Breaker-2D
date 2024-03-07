using System;
using NecatiAkpinar.Abstractions;
using NecatiAkpinar.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NecatiAkpinar.GameElements.Balls
{
    public class NormalBall : BaseBall
    {
        [SerializeField] private float _startingYPosition = 0.6f;

        private Rigidbody2D _rigidBody;

        public Rigidbody2D Rigidbody => _rigidBody;
        private void OnEnable()
        {
            EventManager.GetBall += () => (this);
            EventManager.OnLevelStarted += Launch;;
            EventManager.ResetBallPosition += SetStartPosition;
        }

        private void OnDisable()
        {
            EventManager.GetBall -= () => (this);
            EventManager.OnLevelStarted -= Launch;
            EventManager.ResetBallPosition -= SetStartPosition;
        }

        private void Awake()
        {
            TryGetComponent(out _rigidBody);
            _rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        private void Launch()
        {
            transform.parent = null;
            _rigidBody.constraints = RigidbodyConstraints2D.None;

            var randomForce = Random.Range(Data.StartingForceXRange.x, Data.StartingForceXRange.y);
            _rigidBody.AddForce(new Vector2(randomForce, Data.MovementSpeed), ForceMode2D.Force);
        }

        private void SetStartPosition()
        {
            transform.parent = EventManager.GetPaddle().transform;
            transform.localPosition = new Vector2(0.0f, _startingYPosition);
            _rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        
    }
}