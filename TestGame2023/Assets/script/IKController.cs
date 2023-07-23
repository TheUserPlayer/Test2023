using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour
{
    public List<string> itemTags = new List<string>(); // Список тегов объектов, за которыми будет следить персонаж

    private Animator animator;
    private Transform rightHand;
    private Transform targetObject;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rightHand = animator.GetBoneTransform(HumanBodyBones.RightHand);
    }

    private void Update()
    {
        // Обработка нажатия на объект с одним из заданных тегов
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                foreach (string tag in itemTags)
                {
                    if (hit.collider.CompareTag(tag))
                    {
                        // Задаем объект, к которому персонаж будет тянуть руку и смотреть
                        targetObject = hit.collider.transform;
                        break; // Прерываем цикл, так как уже нашли подходящий тег
                    }
                }
            }
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (targetObject != null)
        {
            // Устанавливаем позицию правой руки
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
            animator.SetIKPosition(AvatarIKGoal.RightHand, targetObject.position);

            // Поворачиваем правую руку, чтобы она смотрела на цель
            Vector3 directionToTarget = targetObject.position - rightHand.position;
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
            animator.SetIKRotation(AvatarIKGoal.RightHand, Quaternion.LookRotation(directionToTarget));

            // Поворачиваем всю модель персонажа в сторону цели
            Vector3 directionToTargetWithoutY = targetObject.position - transform.position;
            directionToTargetWithoutY.y = 0f; // Отключаем влияние Y-координаты для плавного поворота
            Quaternion targetRotation = Quaternion.LookRotation(directionToTargetWithoutY);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f); // Плавный поворот
        }
        else
        {
            // Если targetObject не задан, сбрасываем IK
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);
        }
    }

    public void AnimPlayApple()
    {
        animator.Play("Drop");
    }

    public void AnimPlayPear()
    {
        animator.Play("Drop1");
    }
    public void AnimPlayPeach()
    {
        animator.Play("Drop2");
    }
    public void AnimEnd() {
        animator.Play("DANSE");
    }
}
