using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousObject : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Проверяем, если объект, с которым столкнулись, имеет тег "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Доступ к компоненту здоровья игрока и его уничтожение
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(playerHealth.currentHealth);
            }
        }
    }
}
