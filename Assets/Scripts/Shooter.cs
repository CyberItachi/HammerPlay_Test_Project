using System;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public static event Action<float> onShooterClicked;
    [SerializeField] FixedJoystick _turretController;
    [SerializeField] RectTransform _handle;
    [SerializeField] GameObject _missile;
    [SerializeField] Transform _spawnPoint;
    Transform _turret;
    Quaternion _missileRotation;
    float _power = .1f;
    float angle;

    void Start()
    {
        _turret = transform;
        _missileRotation = _missile.transform.rotation;
    }
    void Update()
    {
        Vector3 _joystickInput = new Vector3(_turretController.Horizontal, _turretController.Vertical, 0f);
        angle = Mathf.Atan2(_joystickInput.y, _joystickInput.x) * Mathf.Rad2Deg;
        if(angle < -20f)
        {
            angle = angle + 360;
        }
        angle = Mathf.Clamp(angle, -21f, 200f);

        if (_joystickInput.x != 0f && _joystickInput.y != 0f)
        {
            _turret.rotation = Quaternion.Euler(0f, 0f, angle);
            _missileRotation = Quaternion.Euler(0f, 0f, angle - 90f);
            _power = Mathf.Sqrt(_joystickInput.x * _joystickInput.x + _joystickInput.y * _joystickInput.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireMissile();
        }
    }

    public void FireMissile()
    {
        GameObject _currentMissile = MissilePool.instance.GetMissile();
        if (_currentMissile != null)
        {
            _currentMissile.transform.rotation = _missileRotation;
            _currentMissile.transform.position = _spawnPoint.transform.position;
            _currentMissile.SetActive(true);
            onShooterClicked?.Invoke(_power);
        }
        
    }   
}
