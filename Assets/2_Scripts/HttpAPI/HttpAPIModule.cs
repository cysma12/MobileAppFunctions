using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HttpAPIModule : MonoBehaviour
{

    private string _url = "http://awseb-e-h-AWSEBLoa-9QEHLYHJ8V4O-1057879182.ap-northeast-2.elb.amazonaws.com";

    private string _loginPath = "/login";
    private string _endPath = "/end";

    private void Start()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            // 인터넷 연결이 안된경우
            ErrorCheck(-1000);
        }
        else
        {
            // 인터넷 연결이 된 경우
            SendAPI(APIType.Login);
        }
    }

    public void SendAPI(APIType _type)
    {
        StartCoroutine(APIRequest(_type));
    }


    #region API_Func
    private IEnumerator APIRequest(APIType _type)
    {

        string tempUrl = GetUrl(_type);
        string json = GetJson(_type);

        using (UnityWebRequest request = UnityWebRequest.Post(tempUrl, json))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            //if (_type == APIType.Login)
            //    request.SetRequestHeader("Connection", "keep-alive");
            request.SetRequestHeader("Content-Type", "application/json");
                       
            //request.SetRequestHeader("Cookie", "test");

            yield return request.SendWebRequest();

            if (request.error != null)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(_type + " return : " + request.downloadHandler.text);
                APIResponse(_type, request.downloadHandler.text);
            }
        }
    }

    private void APIResponse(APIType _type, string content)
    {
        if (_type == APIType.Login)
        {
        }
        else if (_type == APIType.End)
        {     
        }

        Debug.Log(_type.ToString() + " : " + content);
    }


    private string GetUrl(APIType _type)
    {
        string tempValue = "";

        if (_type == APIType.Login) tempValue = _loginPath;
        else if (_type == APIType.End) tempValue = _endPath;

        tempValue = _url + tempValue;
        //Debug.Log(_typ + " Url : " + tempValue);

        return tempValue;
    }

    private string GetJson(APIType _type)
    {
        string tempValue = "";

        if (_type == APIType.Login) tempValue = JsonUtility.ToJson("json text");
        else if (_type == APIType.End) tempValue = JsonUtility.ToJson("json text");

        Debug.Log(_type + " body : " + tempValue);

        return tempValue;
    }
    #endregion



    #region Occur Error
    int ErrorCheck(int _code)
    {
        if (_code > 0) return 0;
        else if (_code == -1000) Debug.LogError(_code + ", Internet Connect Error");
        else if (_code == -1001) Debug.LogError(_code + ", Occur token type Error");
        else if (_code == -1002) Debug.LogError(_code + ", Category type Error");
        else if (_code == -1003) Debug.LogError(_code + ", Item type Error");
        else Debug.LogError(_code + ", Undefined Error");
        return _code;
    }

    int ErrorCheck(int _code, string _funcName)
    {
        if (_code > 0) return 0;
        else if (_code == -400) Debug.LogError(_code + ", Invalid request in " + _funcName);
        else if (_code == -401) Debug.LogError(_code + ", Unauthorized in " + _funcName);
        else if (_code == -404) Debug.LogError(_code + ", not found in " + _funcName);
        else if (_code == -500) Debug.LogError(_code + ", Internal Server Error in " + _funcName);
        else Debug.LogError(_code + ", Undefined Error");
        return _code;
    }
    #endregion
}


public enum APIType
{
    Login,
    End,
    Goods,
    Rewards,
    Exchange_tuna,
    Exchange_whale,
    Exchange_reward,
    Progress,
    InAppPurchase
}