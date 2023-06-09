
using UnityEngine;

public class LevelDataHandler : MonoBehaviour
{
    [SerializeField] private LevelDataRepository _repository;

    public LevelDataRepository Repository => _repository;
}
