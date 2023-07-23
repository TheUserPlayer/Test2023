using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject Apple;
    public GameObject pear;
    public GameObject Peach;
    public IKController IK;
    public TaskManager Tex;
    public GameObject plusOneEffect; // ���������� ������ ��� �������� "+1"

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Apple")
        {
            Apple.SetActive(true);
            IK.AnimPlayApple();
            Tex.AddFruit(0); // ����������� ������� ��������� ����� � TaskManager
            ShowPlusOneEffect(); // ���������� ���������� ������ "+1"
        }
        if (other.tag == "pear")
        {
            pear.SetActive(true);
            IK.AnimPlayPear();
            Tex.AddFruit(1); // ����������� ������� ��������� ���� � TaskManager
            ShowPlusOneEffect(); // ���������� ���������� ������ "+1"
        }
        if (other.tag == "Peach")
        {
            Peach.SetActive(true);
            IK.AnimPlayPeach();
            Tex.AddFruit(2); // ����������� ������� ��������� �������� � TaskManager
            ShowPlusOneEffect(); // ���������� ���������� ������ "+1"
        }
    }

    private void ShowPlusOneEffect()
    {
        // �������� ���������� ������ "+1" (���������� �������� ��� ���������� ��������� �������)
        plusOneEffect.SetActive(true);

        // ��������� ������ ��� ��������, ����� ��������� ���������� ������ ����� ��������� �����
        StartCoroutine(HidePlusOneEffect());
    }

    private IEnumerator HidePlusOneEffect()
    {
        // ���� ��������� ����� (��������, 1 �������) ����� ����������� ����������� �������
        yield return new WaitForSeconds(1f);

        // ��������� ���������� ������ "+1" (��������� �������� ��� �������� ��������� �������)
        plusOneEffect.SetActive(false);
    }
}
