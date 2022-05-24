
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadItemModule : MonoBehaviour
{
    /*
       KeypadItemModule.cs 내 _answerNum 변수 값이랑 키패드가 입력한 값이 같으면 true를 출력하는 함수
     
    */


    public Text CountText;

    private string _tempNum = "";
    private string _resultNum = "";

    private string _answerNum = "580,000";

    private void Awake()
    {
        Reset();
    }

    public void JudgeResult()
    {
        bool result = false;
        if (_answerNum == _resultNum) result = true;

        Debug.Log(result);

        if (!result) ClearKeyNumber(); 
    }

    public void InputKeyNumber(string num)
    {
        _tempNum += num;
        SetResult(_tempNum);
    }

    public void MinusKeyNumber()
    {
        if (_tempNum.Length > 0) _tempNum = _tempNum.Remove(_tempNum.Length - 1, 1);
        else _tempNum = "";
        SetResult(_tempNum);
    }

    public void ClearKeyNumber()
    {
        Reset();
        SetResult(_tempNum);
    }

    private void SetResult(string tempNum)
    {
        if (tempNum == "") _resultNum = "";
        else _resultNum = GetThousandCommaText(ConvertNumber(tempNum));
        CountText.text = _resultNum;
        Debug.Log(_resultNum);
    }

    private int ConvertNumber(string num)
    {
        int value = int.Parse(num);
        return value;
    }

    private string GetThousandCommaText(int data)
    {
        return string.Format("{0:#,###}", data);
    }

    private void Reset()
    {
        _tempNum = "";
        _resultNum = "";
        _tempNum = "0";
    }

}