using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 1.0f;
    private bool movingToB = true;

    void Update()
    {
        // Определяем текущую цель (точку B или точку A)
        Transform target = movingToB ? pointB : pointA;

        // Перемещаем объект к цели
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Проверяем, достиг ли объект цели
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            movingToB = !movingToB;
        }
    }
}
