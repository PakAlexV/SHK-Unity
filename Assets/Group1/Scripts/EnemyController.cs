using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform _selfTransform;
    [SerializeField] private int _speed = 2;
    private GameController _controller; 
    private Vector3 _nextPosition;

    private void Start()
    {
        _controller = GameObject.FindObjectOfType<GameController>();
        NextPositionInit();
    }

    private void NextPositionInit()
    {
        _nextPosition = Random.insideUnitCircle * _controller.RangePositionEnemy;
    }

    private void MoveEnemy()
    {
        _selfTransform.position = Vector3.MoveTowards(_selfTransform.position, _nextPosition, _speed * Time.deltaTime);
        if (_selfTransform.position == _nextPosition)
        {
            NextPositionInit();
        }      
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Vector3 playerPosition = collision.GetComponent<Transform>().position;
            Vector3 enemyPosition = gameObject.GetComponent<Transform>().position;
            if (Vector3.Distance(playerPosition, enemyPosition) < 0.2f)
            {
                _controller.EnemyKill(gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        MoveEnemy();      
    }
}
