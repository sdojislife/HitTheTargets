using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private Target[] _targets;
    public void Spawn() => Instantiate(_targets[Random.Range(0, _targets.Length)]);
    private void Start()
    {
        Spawn();
    }

}