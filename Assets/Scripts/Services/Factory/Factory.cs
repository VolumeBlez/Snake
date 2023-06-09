
using UnityEngine;

public class Factory<T> : IFactory<T> where T : UnityEngine.Object
{
    private readonly PrefabResourceProvider<T> _provider;

    public Factory(string path)
    {
        _provider = new PrefabResourceProvider<T>(path);
    }

    public T Create() 
    {
        return GameObject.Instantiate(_provider.GetPrefab());
    }
}
