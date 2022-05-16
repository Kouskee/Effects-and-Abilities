using UnityEngine;
using UnityEngine.VFX;

public class Trigger : MonoBehaviour
{
    [SerializeField] private VisualEffect _slashEffect;
    [SerializeField] private VisualEffect _groundParticleEffect;
    
    [SerializeField] private float _speed = 5f;

    private float _lifeTimeSlash;
    private float _lifeTimeGroundP;
    
    private void Start()
    {
        _lifeTimeGroundP = _groundParticleEffect.GetFloat("LifeTime");
        _lifeTimeSlash = _slashEffect.GetFloat("SlashLifeTime");
    }

    private void Update()
    {
        if (_lifeTimeSlash > 0)
        {
            _lifeTimeSlash -= Time.deltaTime;
            transform.position += transform.forward * (_speed * Time.deltaTime);
        }
        else
            Destroy();
    }

    private void OnTriggerEnter(Collider other) => Destroy();

    private void Destroy() => Destroy(gameObject, _lifeTimeGroundP);
}