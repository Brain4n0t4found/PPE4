using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebConnectionsScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GetDBHighScores());
    }

    IEnumerator GetDBHighScores()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get("https://portfolioks.fr/ConnexionToDB.php");

        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            string scoresInformations = webRequest.downloadHandler.text;
            Debug.Log(scoresInformations);
        }
    }
}
