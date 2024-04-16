using System.Collections;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody2D _missileBody;
    [SerializeField] float _impulse, _missileLife;
    [SerializeField] ParticleSystem _missileExplode;
    SpriteRenderer _missileRenderer;

    private void Awake()
    {
        this._missileBody = GetComponent<Rigidbody2D>();
        this._missileRenderer = GetComponent<SpriteRenderer>();
    }

    public void Launch(float _power)
    {
        if (!_missileRenderer.enabled)
        {
            _missileRenderer.enabled = true;
        }
        if(_missileBody.constraints == RigidbodyConstraints2D.FreezeAll)
        {
            _missileBody.constraints = RigidbodyConstraints2D.None;
        }
        _missileBody.AddRelativeForce(new Vector2(0f,_power * _impulse), ForceMode2D.Impulse);
        StartCoroutine(MissileLife());
    }

    public IEnumerator MissileLife()
    {
        yield return new WaitForSeconds(_missileLife);
        if(!_missileExplode.isPlaying)
        {
            DestroyMissile();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopCoroutine(MissileLife());
        DestroyMissile();   
    }

    private void DestroyMissile()
    {
        _missileRenderer.enabled = false;
        _missileBody.constraints = RigidbodyConstraints2D.FreezeAll;
        _missileExplode.Play();
        StartCoroutine(DisableMissile());
    }

    public IEnumerator DisableMissile()
    {
        yield return new WaitForSeconds(_missileExplode.main.duration);
        gameObject.SetActive(false);
    }
}
