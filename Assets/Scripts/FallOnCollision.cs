using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOnCollision : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        // �������� ��������� Rigidbody
        rb = GetComponent<Rigidbody>();

        // ������������� ��������� ��������� Rigidbody
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        // ���������, ���� ������, � ������� �����������, ����� ��� "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // �������� ���������� � ��������� ����������, ����� ������ ����� ������
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }
}
