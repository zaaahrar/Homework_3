using UnityEngine;

public class Cherry : MonoBehaviour
{
    private int _heal = 1;
    private bool _isCollect = false;

    public bool IsCollect => _isCollect;
    public int Heal => _heal;

    public void Collect() => _isCollect = true;
}