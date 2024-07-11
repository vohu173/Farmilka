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
        // ���������� ������� ���� (����� B ��� ����� A)
        Transform target = movingToB ? pointB : pointA;

        // ���������� ������ � ����
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // ���������, ������ �� ������ ����
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            movingToB = !movingToB;
        }
    }
}
