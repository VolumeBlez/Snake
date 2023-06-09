
using UnityEngine;

public class PrefabResourceProvider<T> : IPrefabResourceProvider<T> where T : Object
{
    private readonly string path;

    public PrefabResourceProvider(string path) 
    {
        this.path = path;
    }

    public T GetPrefab()
    {
        return Resources.Load<T>(path);
    }
}
