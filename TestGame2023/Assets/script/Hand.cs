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
    public GameObject plusOneEffect; // Визуальный эффект или анимация "+1"

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Apple")
        {
            Apple.SetActive(true);
            IK.AnimPlayApple();
            Tex.AddFruit(0); // Увеличиваем счетчик собранных яблок в TaskManager
            ShowPlusOneEffect(); // Показываем визуальный эффект "+1"
        }
        if (other.tag == "pear")
        {
            pear.SetActive(true);
            IK.AnimPlayPear();
            Tex.AddFruit(1); // Увеличиваем счетчик собранных груш в TaskManager
            ShowPlusOneEffect(); // Показываем визуальный эффект "+1"
        }
        if (other.tag == "Peach")
        {
            Peach.SetActive(true);
            IK.AnimPlayPeach();
            Tex.AddFruit(2); // Увеличиваем счетчик собранных персиков в TaskManager
            ShowPlusOneEffect(); // Показываем визуальный эффект "+1"
        }
    }

    private void ShowPlusOneEffect()
    {
        // Включаем визуальный эффект "+1" (активируем анимацию или отображаем текстовый элемент)
        plusOneEffect.SetActive(true);

        // Запускаем таймер или корутину, чтобы отключить визуальный эффект через некоторое время
        StartCoroutine(HidePlusOneEffect());
    }

    private IEnumerator HidePlusOneEffect()
    {
        // Ждем некоторое время (например, 1 секунду) перед отключением визуального эффекта
        yield return new WaitForSeconds(1f);

        // Отключаем визуальный эффект "+1" (выключаем анимацию или скрываем текстовый элемент)
        plusOneEffect.SetActive(false);
    }
}
