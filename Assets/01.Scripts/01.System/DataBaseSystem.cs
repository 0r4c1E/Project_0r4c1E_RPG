using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataBaseSystem : MonoBehaviour
{
    public static DataBaseSystem inst;
    private const string requestURL = "http://localhost:3000/GameData";

    private void Awake() {
        inst = this;
    }

    public void TestBtn(){
        StartCoroutine(Upload("{key:value}"));
    }
    IEnumerator Upload(string profile, System.Action<bool> callback = null)
{
    using (UnityWebRequest request = new UnityWebRequest(requestURL, "POST"))
    {
        request.SetRequestHeader("Content-Type", "application/json");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(profile);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
            if(callback != null) 
            {
                callback.Invoke(false);
            }
        }
        else
        {
            if(callback != null) 
            {
                callback.Invoke(request.downloadHandler.text != "{}");
            }
        }
    }
}
}
