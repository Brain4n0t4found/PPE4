using System.IO;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Newtonsoft.Json.Linq;

public class GetDataFromJson : Component
{
    private string JsonContent = File.ReadAllText("ObjectsData.json");

    public void SearchDataFromJsonRessources()
    {
        Debug.Log(JsonContent);
        JObject o = JObject.Parse(JsonContent);
        MainCharacterScript character = o.SelectToken("Assets/Data/character.john").Value<MainCharacterScript>();
        Debug.Log(character.Name);
    }
}
