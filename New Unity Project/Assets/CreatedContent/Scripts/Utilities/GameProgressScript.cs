// Using System
using System.Collections;
using System.Linq;

// using Unity
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CreatedContent.Scripts.Utilities
{
    public class GameProgressScript : MonoBehaviour
    {

        #region Properties
        private static MainCharacterScript MainCharacter { get; set; }
        private static BuildingScript BuildingScript { get; set; }
        private int sceneIndex { get; set; }
        #endregion

        #region Unity Functions
        public void Start()
        {
            SceneManager.activeSceneChanged += ChangedActiveScene;
        }

        public void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
        #endregion

        #region Functions
        public void CreateScene(bool isFirstTimeBuildingScene)
        {
            sceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Création du personnage si c'est la première scène créée
            if (isFirstTimeBuildingScene)
            {
                // Récupération du personnage
                MainCharacterModel characterModel = GetDataFromJson.mainCharacterModelsList.Where(mainCharac => mainCharac.Name == "John").First();

                // Création du personnage
                MainCharacter = ObjectFactory.CreateCharacter(characterModel.Name, characterModel.Health, characterModel.EnergyAmount);

                sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            }

            SceneManager.LoadScene(sceneIndex);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void GoToBuilding()
        {
            Transform doorTransform = GameObject.Find("BuildingDoor").GetComponent<Transform>();
            MainCharacter.MoveToPosition(doorTransform.position.x);
        }

        public void ChangeFloor(int numberToChange)
        {
            MainCharacter.BuildingFloorPosition += numberToChange;
            
            // Définition de si le personnage affronte un ennemi à l'étage où il est
            if (BuildingScript.FloorList[MainCharacter.BuildingFloorPosition].EnemyScript != null)
            {
                MainCharacter.IsFighting = true;
            }
        }

        public void SpawnCharacterOutside()
        {
            MainCharacter.transform.position = new Vector3(-7.5f, -2.3f, -1f);
        }
        #endregion

        #region Events
        private void ChangedActiveScene(Scene current, Scene next)
        {
            // Récupération du bâtiment
            BuildingModel buildingModel = GetDataFromJson.buildingModelsList.Where(build => build.Name == "Commissariat").First();

            // Création du bâtiment
            ObjectFactory.CreateBuilding(buildingModel.Name, buildingModel.FloorsNumber);
        }
        #endregion
    }
}
