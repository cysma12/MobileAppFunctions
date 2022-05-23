using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    /* 
        �ش� �ڵ�� ������ ���� �� ������ ���� ���� ����� �����߽��ϴ�.        
        
        ����
        1. ���� �ϳ��� QuizManager.cs�� �Ҵ��մϴ�.
        2. ���⿡ QuizItem.cs�� �Ҵ��մϴ�.
        3. ���⿡�� ������ QuizItem.IsTrue = true��, ������ false�� �մϴ�.       
    */


    public delegate void FinishEvent();
    public FinishEvent OnFinish;

    public QuizItem[] QuizItems;


    private void Awake()
    {
        ShowQuiz(0);
    }

    public void ShowQuiz(int num)
    {

        QuizItems[num].ShowQuizItem(true);
    }

    public void HideQuiz()
    {
        for (int i = 0; i < QuizItems.Length; i++)
            QuizItems[i].ShowQuizItem(false);
    }

    public void CheckTrue(string quizName)
    {
        Debug.Log(quizName + " : True");

        if (OnFinish != null)
            OnFinish();
    }

    public void CheckFalse()
    {
        Debug.Log("False");
    }
}
