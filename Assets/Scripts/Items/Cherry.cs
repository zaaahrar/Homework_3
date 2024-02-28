using UnityEngine;

public class Cherry : MonoBehaviour
{
    [SerializeField] private int _heal;

    public int Heal => _heal;
}