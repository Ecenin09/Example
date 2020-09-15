using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float movementSpeed = 10f;
    private float _directionMove;
    private Rigidbody2D _playerRb;
    public Text jewelText;
    private int _jewelCount = 0;
    
    private void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>(); // Метод для получения Rigidbody2D игрового объекта
        _jewelCount = 0;
    }
    
    private void Update()
    {
        // Перед тем как сделать билд для телефона - выбираем нужный тип управления
        // не нужный тип - комментируем
        #if UNITY_EDITOR
            _directionMove = Input.GetAxis("Horizontal")*movementSpeed; // для работы в редакторе
        #elif UNITY_ANDROID
            _directionMove = Input.acceleration.x * movementSpeed;    // для работы на телефоне
        #endif
    
}

    private void FixedUpdate()
    {
        Vector2 velocity = _playerRb.velocity;
        velocity.x = _directionMove;
        _playerRb.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jewel"))
        {
            _jewelCount++;
            jewelText.text = Convert.ToString(_jewelCount);
        }
    }
}
