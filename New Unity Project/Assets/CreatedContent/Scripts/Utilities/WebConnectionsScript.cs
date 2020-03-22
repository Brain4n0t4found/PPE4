using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebConnectionsScript : MonoBehaviour
{
    // Appel des fontions via "StartCoroutine(<fonction>)"

    /// <summary>
    /// Récupère les 10 meilleurs scores de la BDD
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Envoie le score à la BDD
    /// </summary>
    /// <returns></returns>
    IEnumerator PostDBScore()
    {
        yield return null;
    }
}
