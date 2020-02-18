using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _selfTransform;
    [SerializeField] private int _speedPlayer = 3;
    
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _selfTransform.Translate(0, _speedPlayer * Time.deltaTime, 0);
        }       
        if (Input.GetKey(KeyCode.S))
        {
            _selfTransform.Translate(0, -_speedPlayer * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _selfTransform.Translate(-_speedPlayer * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _selfTransform.Translate(_speedPlayer * Time.deltaTime, 0, 0);
        }        
    }
}
