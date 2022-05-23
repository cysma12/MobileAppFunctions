using System;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class MixRandomArray
{
    /* 
     함수에 배열을 넣으면 배열내 값이 랜덤으로 섞여 리턴 된다. 
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

