// Using System
using System.IO;
using System.Collections.Generic;
using System.Linq;

// Using packages
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using UnityEngine;

public static class GetDataFromJson
{
    #region properties
    private static string JsonContent { get; set; }

    #region Listes de modeles avec les valeurs du JSON
    public static List<BuildingModel> buildingModelsList { get; set; }
    public static List<ContainerModel> containerModelsList { get; set; }
    public static List<EnemyModel> enemyModelsList { get; set; }
    public static List<EquipmentObjectModel> equipmentObjectModelsList { get; set; }
    public static List<MainCharacterModel> mainCharacterModelsList { get; set; }
    public static List<StateModel> stateModelsList { get; set; }
    public static List<WeaponModel> weaponModelsList { get; set; }
    public static List<EnemyModel> bossModelsList { get; set; }
    public static List<string> existingObjectsName { get; set; }
    #endregion

    #endregion

    #region Functions
    /// <summary>
    /// Attribution des ressources JSON
    /// </summary>
    public static void setClassContent()
    {
        // Crée un reader à partir du chemin vers le fichier de ressources du projet
        StreamReader jsonReader = new StreamReader(JsonPathes.PathToJsonData);

        // Applique le contenu du reader à JsonContent
        JsonContent = jsonReader.ReadToEnd();

        // Remplit les liste de models
        buildingModelsList = SearchDataFromJsonRessources<BuildingModel>(JsonPathes.BuildingsPath);
        containerModelsList = SearchDataFromJsonRessources<ContainerModel>(JsonPathes.FurnituresPath);
        enemyModelsList = SearchDataFromJsonRessources<EnemyModel>(JsonPathes.MonstersPath);
        equipmentObjectModelsList = SearchDataFromJsonRessources<EquipmentObjectModel>(JsonPathes.ItemsPath);
        mainCharacterModelsList = SearchDataFromJsonRessources<MainCharacterModel>(JsonPathes.CharactersPath);
        stateModelsList = SearchDataFromJsonRessources<StateModel>(JsonPathes.StatusPath);
        weaponModelsList = SearchDataFromJsonRessources<WeaponModel>(JsonPathes.WeaponsPath);
        bossModelsList = SearchDataFromJsonRessources<EnemyModel>(JsonPathes.BossesPath);

        // Remplit la liste de noms d'objets
        existingObjectsName = new List<string>();
        foreach(EquipmentObjectModel obj in equipmentObjectModelsList)
        {
            if (!existingObjectsName.Any(existObjName => existObjName == obj.Name))
            {
                existingObjectsName.Add(obj.Name);
            }
        }
    }

    /// <summary>
    /// Renvoie une List<> d'objets contenant les données JSON demandées
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="valueToSearch"></param>
    /// <returns>List<typeparamref name="T"/></returns>
    private static List<T> SearchDataFromJsonRessources<T>(string valueToSearch)
    {
        // Récupère les données du fichier JSON dans un objet JSON
        JObject jObject = JObject.Parse(JsonContent);

        // Récupère et renvoie l'objet demandé
        return JsonConvert.DeserializeObject<List<T>>(jObject[valueToSearch].ToString());
    }
    #endregion
}

public static class JsonPathes
{
    #region Chemin vers le fichier
    public static readonly string PathToJsonData = "Assets/CreatedContent/Data/ObjectsData.json";
    #endregion

    #region Chemin dans le JSON vers les différents éléments
    public static readonly string BuildingsPath = "buildings";
    public static readonly string FurnituresPath = "furnitures";
    public static readonly string CharactersPath = "characters";
    public static readonly string WeaponsPath = "weapons";
    public static readonly string ItemsPath = "items";
    public static readonly string MonstersPath = "monsters";
    public static readonly string BossesPath = "bosses";
    public static readonly string StatusPath = "status";
    #endregion
}