using UnityEngine;

public class Food : MonoBehaviour, IEatable
{
    public void Eat()
    {
        Destroy(gameObject);
    }
}
