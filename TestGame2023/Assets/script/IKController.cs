using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour
{
    public List<string> itemTags = new List<string>(); // ������ ����� ��������, �� �������� ����� ������� ��������

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
        // ��������� ������� �� ������ � ����� �� �������� �����
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
                        // ������ ������, � �������� �������� ����� ������ ���� � ��������
                        targetObject = hit.collider.transform;
                        break; // ��������� ����, ��� ��� ��� ����� ���������� ���
                    }
                }
            }
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (targetObject != null)
        {
            // ������������� ������� ������ ����
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
            animator.SetIKPosition(AvatarIKGoal.RightHand, targetObject.position);

            // ������������ ������ ����, ����� ��� �������� �� ����
            Vector3 directionToTarget = targetObject.position - rightHand.position;
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
            animator.SetIKRotation(AvatarIKGoal.RightHand, Quaternion.LookRotation(directionToTarget));

            // ������������ ��� ������ ��������� � ������� ����
            Vector3 directionToTargetWithoutY = targetObject.position - transform.position;
            directionToTargetWithoutY.y = 0f; // ��������� ������� Y-���������� ��� �������� ��������
            Quaternion targetRotation = Quaternion.LookRotation(directionToTargetWithoutY);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f); // ������� �������
        }
        else
        {
            // ���� targetObject �� �����, ���������� IK
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
