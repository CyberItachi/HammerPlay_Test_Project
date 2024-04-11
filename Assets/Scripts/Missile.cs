using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody2D _missileBody;
    [SerializeField] float _impulse;

    private void Awake()
    {
        this._missileBody = GetComponent<Rigidbody2D>();
    }

    public void Launch(float _power)
    { 
        _missileBody.AddRelativeForce(new Vector2(0f,_power * _impulse), ForceMode2D.Impulse);
    }
}
