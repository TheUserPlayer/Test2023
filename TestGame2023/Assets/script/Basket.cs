using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Basket : MonoBehaviour
{
    public GameObject[] appleObjects;
    public GameObject[] pearObjects;
    public GameObject[] peachObjects;

    private int[] appleCount;
    private int[] pearCount;
    private int[] peachCount;

    private void Start()
    {
        appleCount = new int[appleObjects.Length];
        pearCount = new int[pearObjects.Length];
        peachCount = new int[peachObjects.Length];
    }

    public void InvokeTimeApple()
    {
        Invoke("BasketFApple", 0.1f);
    }

    public void InvokeTimePear()
    {
        Invoke("BasketFPear", 0.1f);
    }

    public void InvokeTimePeach()
    {
        Invoke("BasketFPeach", 0.1f);
    }

    public void BasketFApple()
    {
        AddFruit(ref appleCount, appleObjects);
    }

    public void BasketFPear()
    {
        AddFruit(ref pearCount, pearObjects);
    }

    public void BasketFPeach()
    {
        AddFruit(ref peachCount, peachObjects);
    }

    private void AddFruit(ref int[] countArray, GameObject[] fruitObjects)
    {
        for (int i = 0; i < countArray.Length; i++)
        {
            if (countArray[i] == 0)
            {
                fruitObjects[i].SetActive(true);
                countArray[i]++;
                break;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AppleHend")
        {
            Debug.Log("Apple");
            InvokeTimeApple();
        }
        if (other.tag == "PearHend")
        {
            Debug.Log("pear");
            InvokeTimePear();
        }
        if (other.tag == "PeachHend")
        {
            Debug.Log("Peach");
            InvokeTimePeach();
        }


    }
}
