using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverLayer;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemyPrefab; 
    [SerializeField] private int _countEnemy = 4;
    [SerializeField] private int _rangePositionEnemy = 4;
    private List<GameObject> _enemys = new List<GameObject>();

    public int RangePositionEnemy { get => _rangePositionEnemy; }

    private void Start()
    {
        for (int i = 0; i < _countEnemy; i++)
        {
            GameObject enemy = Instantiate(_enemyPrefab, Random.insideUnitCircle * _rangePositionEnemy, Quaternion.identity);
            _enemys.Add(enemy);
        }
    }

    private void OnGameEnd()
    {
        _gameOverLayer.SetActive(true);
    }

    public void EnemyKill(GameObject enemy)
    {
        if (enemy != null)
        {
            Destroy(enemy);
            _enemys.Remove(enemy);        
            if (_enemys.Count == 0)
            {
                OnGameEnd();
            }
        }
    }
}
