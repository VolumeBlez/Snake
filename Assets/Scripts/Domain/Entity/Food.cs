using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Food : MonoBehaviour, IEatable
{
    [SerializeField] private AnimationClip _deathClip;
    private Animator _anim;

    private void OnEnable() 
    {
        _anim = GetComponent<Animator>();  
    }

    public void Eat()
    {
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation() 
    {
        _anim.enabled = true;
        _anim.SetTrigger("Eat");

        yield return new WaitForSeconds(_deathClip.length);

        _anim.enabled = false;
        DestroyFood();
    }

    private void DestroyFood() 
    {
        Destroy(gameObject);
    }
}
