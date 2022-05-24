using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class VersionChecker : MonoBehaviour
{
    //�ش� ��ũ��Ʈ�� �� ������ ���� ���׷��̵� ������ Ȯ���� �ִ� ��ũ��Ʈ�Դϴ�.
    //Nuget ��Ű������ HtmlAgilityPack�� �߰��� �ֽø� HtmlAgilityPack�� ����Ͻ� �� �ֽ��ϴ�.


    public GameObject versioncheck_pannel; //���� ������Ʈ �˸�â ������Ʈ

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
                    Debug.Log("�� �� ���� :" + Application.version);
                    Debug.Log("���� ���� : " + marketVersion);

                    string a = marketVersion.ToString();
                    string b = Application.version.ToString();

                    if (a == b)
                    {
                        //������ ���� ������ �˸��� ���� �ʴ´�.
                    }
                    else if (a != b)
                    {
                        //������ �ٸ��� ������ �˸��� ���.
                        versioncheck_pannel.SetActive(true);
                    }
                }
            }
        }
    }

    public void OpenURL(string url) //�Էµ� ��ũ�� ���� ����� �̵�
    {
        Application.OpenURL(url);
    }
}