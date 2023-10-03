using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerCrystals : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private Crystal _instance;

    private Transform[] _positions;

    private void Start()
    {
        FillArray();
        SpawnCrystals();
    }

    private void FillArray()
    {
        _positions = new Transform[_parent.childCount];

        for (int i = 0; i < _parent.childCount; i++)
        {
            _positions[i] = _parent.GetChild(i);
        }
    }

    private void SpawnCrystals()
    {
        foreach (Transform position in _positions)
        {
            Instantiate(_instance, position);
        }
    }
}
