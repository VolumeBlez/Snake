
public interface IPrefabResourceProvider<out T> where T : UnityEngine.Object
{
    T GetPrefab();
}
