using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Если относительная скорость будет 0 или меньше
        if (collision.relativeVelocity.y <= 0f)
        {
            // то получить ссылку на компонент
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            // если ссылку получили - значит колизия с нужным нам объектом
            if (playerRb != null)
            {
                // задаём направление вверх и добавляем ускорение нашему игровому объекту
                playerRb.velocity=Vector2.up*jumpForce;
                // Получаем все массив компонентов со всех детей
                SpriteRenderer[] colorChildren = gameObject.GetComponentsInChildren<SpriteRenderer>();
                // Изменяем параметры компонента у всех детей
                foreach (var child in colorChildren)
                {
                    child.color=Color.red;
                }
                
                Destroy(gameObject,5f);
            }  
        }
    }
}
