using UnityEngine;
using System.Collections;

public class ObjectMover : MonoBehaviour
{
    public Transform targetPosition; // �������� ����� ��� ����������� ������� (��������������� ����� ���������)
    public float moveSpeed = 2f; // �������� ����������� �������

    // ����� ��� �������� ����������� ������� �� �������� � ����������� ��� � �������� �����
    public void MoveToTarget()
    {
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        // ���������� ������ �� ��������
        transform.parent = null;

        // ���������� ������ � �������� �����
        while (Vector3.Distance(transform.position, targetPosition.position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // ����������, ��� ������ ����� ������ �������� �����
        transform.position = targetPosition.position;
    }
}
