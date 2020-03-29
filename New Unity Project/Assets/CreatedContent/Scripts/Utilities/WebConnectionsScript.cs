// using System
using System;
using System.Collections;
using System.Collections.Generic;

// using Unity
using UnityEngine;
using UnityEngine.Networking;

// using Packages
using Newtonsoft.Json;

public class WebConnectionsScript : MonoBehaviour
{
    #region Properties
    public static string ContentFromDB { get; set; }
    public static List<ScoreFromDB> ScoreFromDBs { get; set; }
    #endregion

    // Permet au gameObject de ne pas être détruit lors du changement de scènes
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        RequestDBHighScores();
    }

    #region Functions
    // Appel des fontions via "StartCoroutine(<nomFonction>)"
    public static void RequestDBHighScores()
    {
        ScoreFromDBs = TransformDataFromDB<List<ScoreFromDB>>("https://portfolioks.fr/ConnexionToDB.php");

        foreach (ScoreFromDB score in ScoreFromDBs)
        {
            Debug.Log("Joueur numéro " + (ScoreFromDBs.IndexOf(score) + 1) + " : ");
            Debug.Log("  Nom du joueur : " + score.Name);
            Debug.Log("  Score du joueur : " + score.Score);
            Debug.Log("  Date du score : " + score.DateAndTime.ToLongDateString() + " à " + score.DateAndTime.TimeOfDay);
        }
    }

    #region Generic functions
    private static T TransformDataFromDB<T>(string requestUrl)
    {
        // Traitement de la requête
        IEnumerator req = GetDataFromDB(requestUrl);

        // Blocage tant que la requête n'est pas terminée
        while (req.MoveNext());

        try
        {
            return JsonConvert.DeserializeObject<T>(ContentFromDB);
        }
        catch (Exception exc)
        {
            // Log
            Debug.Log("Erreur lors de la conversion du JSON de la requête web : " + exc.Message);

            // Retourne une valeur vide
            return default(T);
        }
    }

    private static IEnumerator GetDataFromDB(string requestUrl)
    {
        // Log
        Debug.Log("Début de la requête GetDataFromDB() à l'adresse : " + requestUrl);

        // Création de la requête
        UnityWebRequest webRequest = UnityWebRequest.Get(requestUrl);

        // Envoi de la requête
        yield return webRequest.SendWebRequest();

        // Log
        Debug.Log("Progression de la requête : ");

        // Renvoie true tant que la requête n'est pas terminée
        while (!webRequest.isDone)
        {
            Debug.Log(webRequest.downloadProgress * 100 + "%");

            yield return null;
        }

        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            // Log
            Debug.Log("Requête effectuée avec succés");

            // Attribution de la valeur de retour de requête
            ContentFromDB = webRequest.downloadHandler.text;
        }
    }
    #endregion

    #endregion
}

// Classe des scores
public class ScoreFromDB
{
    #region Properties
    public DateTime DateAndTime { get; set; }
    public string Name { get; set; }
    public decimal Score { get; set; }
    #endregion
}
