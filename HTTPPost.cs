using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HTTPPost : MonoBehaviour
{
    public Text text;
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(Post());
    }
    IEnumerator Post()
    {
        WWWForm form = new WWWForm();
        form.AddField("page", "1");
        form.AddField("limit", "20");
        UnityWebRequest webRequest = UnityWebRequest.Post("http://pc.hbeasts.com/fingernft/user/collections", form);

        yield return webRequest.SendWebRequest();


        if (webRequest.isHttpError || webRequest.isNetworkError)
            Debug.Log(webRequest.error);
        else
        {
            text.text = webRequest.downloadHandler.text;
        }
    }
}
    
