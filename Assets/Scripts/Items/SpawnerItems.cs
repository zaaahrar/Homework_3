using UnityEngine;

public class SpawnerItems : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject _instance;

    private Transform[] _positions;

    private void Awake()
    {
        FillArray();
        Spawn();
    }

    private void FillArray()
    {
        _positions = new Transform[_parent.childCount];

        for (int i = 0; i < _parent.childCount; i++)
        {
            _positions[i] = _parent.GetChild(i);
        }
    }

    private void Spawn()
    {
        foreach(Transform position in _positions)
        {
            Instantiate(_instance, position);
        }
    }
}
