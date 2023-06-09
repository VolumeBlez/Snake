using UnityEngine;

public class DeathParticleInvoker : IEventListener
{
    private readonly ParticleSystem _particle;
    private readonly Transform _origin;

    public EventType ListenEventType => EventType.SnakeDeath;

    public DeathParticleInvoker(ParticleSystem particle, Transform origin)
    {
        this._particle = particle;
        this._origin = origin;
    }

    public void EventTriggeredAction()
    {
        _particle.gameObject.SetActive(true);
        _particle.transform.position = _origin.position;
        _particle.Play();
    }
}
