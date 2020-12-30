using UnityEngine;

namespace SimTask.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private Vector2 _direction;
        [SerializeField, Range(10f, 1000f)] private float speed = 200f;

        private void Start()
        {
            //Setting up rigidbody settings.
            TryGetComponent(out _rb);
            _rb.gravityScale = 0f;
            _rb.isKinematic = false;
            _rb.angularDrag = 0f;
        }

        private void CalculateDirection()
        {
            _direction = 
                PlayerState.CurrentState == PlayerState.State.Free ? 
                new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized 
                  : Vector2.zero;
        }

        private void Update()
        {
            CalculateDirection();
        }

        private void FixedUpdate()
        {
            _rb.velocity = _direction * speed * Time.fixedDeltaTime;
        }
    }
}