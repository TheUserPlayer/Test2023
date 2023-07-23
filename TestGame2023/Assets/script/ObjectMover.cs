using UnityEngine;
using System.Collections;

public class ObjectMover : MonoBehaviour
{
    public Transform targetPosition; // Заданная точка для перемещения объекта (устанавливается через инспектор)
    public float moveSpeed = 2f; // Скорость перемещения объекта

    // Метод для плавного открепления объекта от родителя и перемещения его в заданную точку
    public void MoveToTarget()
    {
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        // Открепляем объект от родителя
        transform.parent = null;

        // Перемещаем объект к заданной точке
        while (Vector3.Distance(transform.position, targetPosition.position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Убеждаемся, что объект точно достиг заданной точки
        transform.position = targetPosition.position;
    }
}
