using UnityEngine;
public class TankMovement : MonoBehaviour
{
    [SerializeField] float _tankSpeed;
    [SerializeField] FixedJoystick _tankMover;
    Rigidbody2D _tankRigidbody;
    float _movementFactor;
    
    private void Start()
    {
        _tankRigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        _movementFactor = _tankMover.Horizontal;
        if(_tankMover.Horizontal != 0)
        {
            MoveTank(_movementFactor);
        }
    }
    
    private void MoveTank(float _movementFactor)
    {
        Vector2 tankVelocity = new Vector2(_movementFactor * _tankSpeed * Time.fixedDeltaTime, 0f);
        _tankRigidbody.velocity = tankVelocity;
    }
}
