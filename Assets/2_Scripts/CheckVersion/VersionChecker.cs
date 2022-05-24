using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class VersionChecker : MonoBehaviour
{
    //해당 스크립트는 앱 버전을 비교해 업그레이드 유무를 확인해 주는 스크립트입니다.
    //Nuget 패키지에서 HtmlAgilityPack를 추가해 주시면 HtmlAgilityPack를 사용하실 수 있습니다.


    public GameObject versioncheck_pannel; //게임 업데이트 알림창 오브젝트

    private void Start()
    {
        UnsafeSecurityPolicy.Instate();
        string marketVersion = "";

        string url = "https://play.google.com/store/apps/details?id=com.yjoy.SoldierStory"; 
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = web.Load(url);

        foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//span[@class='htlgb']"))
        {
            marketVersion = node.InnerText.Trim();
            if (marketVersion != null)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(marketVersion, @"^\d{1}\.\d{1}\.\d{1}$"))
                {
                    Debug.Log("내 앱 버전 :" + Application.version);
                    Debug.Log("마켓 버전 : " + marketVersion);

                    string a = marketVersion.ToString();
                    string b = Application.version.ToString();

                    if (a == b)
                    {
                        //버전이 같기 때문에 알림이 뜨지 않는다.
                    }
                    else if (a != b)
                    {
                        //버전이 다르기 때문에 알림이 뜬다.
                        versioncheck_pannel.SetActive(true);
                    }
                }
            }
        }
    }

    public void OpenURL(string url) //입력된 링크에 따라 스토어 이동
    {
        Application.OpenURL(url);
    }
}