using System;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class MixRandomArray
{
    /* 
     �Լ��� �迭�� ������ �迭�� ���� �������� ���� ���� �ȴ�. 
    */


    public int[] MixArray(int[] arrayData)
    {
        int[] arr = arrayData;
        System.Random random = new System.Random();

        arr = arr.OrderBy(x => random.Next()).ToArray();

        foreach (var i in arr)
        {
            Debug.Log(i);
        }

        return arr;
    }
}

