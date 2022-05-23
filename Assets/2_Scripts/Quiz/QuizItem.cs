using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class QuizItem : MonoBehaviour
{

    public QuizManager QuizManager;

    public string QuizName = "";

    public bool IsTrue = false;

    public Image QuastionImage;
    public Image TrueImage;
    public Image FalseImage;

    public Button QuizButton;

    public delegate void QuastionEvent();
    public delegate void TrueEvent();
    public delegate void FalseEvent();

    public QuastionEvent OnQuastionEvent;
    public TrueEvent OnTrueEvent;
    public FalseEvent OnFalseEvent;

    private float _fadeTime = 0.5f;

    private void Awake()
    {
        Init();
    }

    public void ShowQuizItem(bool isShow)
    {
        if (isShow)
        {
            if (OnQuastionEvent != null)
                OnQuastionEvent();

            QuastionImage.DOFade(1, _fadeTime);

            SetButtonState(true);
        }
        else
        {
            QuastionImage.DOFade(0, _fadeTime);
            TrueImage.DOFade(0, _fadeTime);
            FalseImage.DOFade(0, _fadeTime);
            SetButtonState(false);
        }
    }

    public void ClickButton()
    {
        SetButtonState(false);

        if (IsTrue)
        {
            if (OnTrueEvent != null) OnTrueEvent();

            TrueImage.DOFillAmount(1, _fadeTime)
                .OnComplete(delegate() {
                    TrueImage.DOFillAmount(0, 0);
                    SetButtonState(true);
                }) ;
       
            QuizManager.CheckTrue(QuizName);
        }
        else
        {
            if (OnFalseEvent != null) OnFalseEvent();
      
            QuizManager.CheckFalse();
            FalseImage.DOFade(1, _fadeTime)     
                .OnComplete(delegate () {         
                    FalseImage.DOFade(0, 0);
                    SetButtonState(true);          
                });
        }
    }
    private void SetButtonState(bool isActive)
    {
        QuizButton.enabled = isActive;
    }

    private void Init()
    {

        //QuastionImage.DOFade(0._fadeTime).OnComplete();
        QuastionImage.DOFade(0, 0);
        TrueImage.DOFillAmount(0, 0);
        FalseImage.DOFade(0, 0);
        SetButtonState(true);
    }
}