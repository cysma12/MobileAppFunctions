using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    /* 
        해당 코드는 여러개 보기 중 정답을 고르는 퀴즈 기능을 구현했습니다.        
        
        구현
        1. 문제 하나에 QuizManager.cs를 할당합니다.
        2. 보기에 QuizItem.cs를 할당합니다.
        3. 보기에서 정답은 QuizItem.IsTrue = true를, 오답은 false로 합니다.       
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
