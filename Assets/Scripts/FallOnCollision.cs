using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOnCollision : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        // Получаем компонент Rigidbody
        rb = GetComponent<Rigidbody>();

        // Устанавливаем начальные параметры Rigidbody
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Проверяем, если объект, с которым столкнулись, имеет тег "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Включаем гравитацию и отключаем кинематику, чтобы объект начал падать
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }
}
