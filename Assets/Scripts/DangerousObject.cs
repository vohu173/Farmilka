using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousObject : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // ���������, ���� ������, � ������� �����������, ����� ��� "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // ������ � ���������� �������� ������ � ��� �����������
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(playerHealth.currentHealth);
            }
        }
    }
}
