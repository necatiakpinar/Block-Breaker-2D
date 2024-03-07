using NecatiAkpinar.Abstractions;
using NecatiAkpinar.Managers;
using UnityEngine;

namespace NecatiAkpinar.Controllers
{
    [RequireComponent(typeof(BasePaddle))]
    public class InputController : MonoBehaviour
    {
        [SerializeField] private float _minXPosition = -7;
        [SerializeField] private float _maxXPosition = 7;

        private BasePaddle _paddle;

        private readonly string _axisKey = "Horizontal";
        private void Awake()
        {
            TryGetComponent(out _paddle);
        }

        private void Update()
        {
            HandleMovement();
            HandleBallLaunch();
        }

        private void HandleMovement()
        {
            if (_paddle == null)
                return;

            float horizontal = Input.GetAxis(_axisKey);
            transform.Translate(Vector2.right * horizontal * Time.deltaTime * _paddle.Data.MovementSpeed);

            if (transform.position.x < _minXPosition)
                transform.position = new Vector2(_minXPosition, transform.position.y);
            if (transform.position.x > _maxXPosition)
                transform.position = new Vector2(_maxXPosition, transform.position.y);
            
        }

        private void HandleBallLaunch()
        {
            if (EventManager.GetBall().Rigidbody.velocity == Vector2.zero && Input.GetKeyDown(KeyCode.Space))
                EventManager.OnLevelStarted?.Invoke();
        }
    }
}