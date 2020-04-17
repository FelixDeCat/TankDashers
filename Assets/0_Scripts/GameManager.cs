using DevelopTools;
using System;
using System.Collections.Generic;
using System.Linq;
using Tools;
using UnityEngine;
//using XInputDotNetPure;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool gameisbegin;
    bool inmenu;

    //[SerializeField] CharacterHead character;

    [Header("Inspector References")]
    EventManager eventManager;
    Rumble rumble;
    
    [SerializeField] List<PlayObject> allentities;

    public GameUI_controller gameUiController;

    public void SubscriteToEntities(PlayObject po) => allentities.Add(po);
    public void UnsubscribeToEntities(PlayObject po) => allentities.Remove(po);

    private void Awake()
    {
        instance = this;
        eventManager = new EventManager();
        rumble = new Rumble();
    }

    void Start()
    {
        gameUiController.Initialize();
    }

    private void Update()
    {
        rumble.OnUpdate();
    }

    void AddToMainCollection(IEnumerable<PlayObject> col) { allentities = col.ToList(); OnLoadEnded(); }

    void OnLoadEnded()
    {
        gameisbegin = true;
        Play();
        eventManager.TriggerEvent(GameEvents.GAME_END_LOAD);
    }

    public void EVENT_OpenMenu() { if (gameisbegin) gameUiController.OpenMenu(); }

    public List<T> GetListOf<T>() where T : PlayObject
    {
        List<T> aux = new List<T>();
        foreach (var obj in allentities)
        {
            if (obj.GetType() == typeof(T))
            {
                aux.Add((T)obj);
            }
        }
        return aux;
    }

    public List<T> GetListOfComponent<T>() where T : PlayObject
    {
        List<T> aux = new List<T>();
        foreach (var obj in allentities)
        {
            var myComp = obj.GetComponent<T>();

            if (myComp != null)
            {
                aux.Add((T)obj);
            }
        }
        return aux;
    }

    public void OnPlayerDeath() { }

    public void PlayerDeath()
    {
        //if (FindObjectOfType<SceneMainBase>())
        //{
        //    FindObjectOfType<SceneMainBase>().OnPlayerDeath();
        //}
    }

    public void Play() { foreach (var e in allentities) e.Resume(); }
    public void Pause() { foreach (var e in allentities) e.Pause(); }


    /////////////////////////////////////////////////////////////////////
    /// PUBLIC GETTERS
    /////////////////////////////////////////////////////////////////////
    ///
    public EventManager GetEventManager() => eventManager;
    public List<EnemyBase> GetEnemies() => GetListOfComponent<EnemyBase>();
    public MyEventSystem GetMyEventSystem() => MyEventSystem.instance;
    public bool Ui_Is_Open() => gameUiController.openUI;
    public void Vibrate() => rumble.OneShootRumble();
    public void Vibrate(float _strengh = 1, float _time_to_rumble = 0.2f) => rumble.OneShootRumble(_strengh, _time_to_rumble);



    //#region REMPLAZAR TODO ESTO POR UN GETSPAWNER() Y QUIEN LO NECESITE LO HAGA DESDE SU CODIGO
    //Spawner spawner = new Spawner();

    //public ItemWorld SpawnItem(ItemWorld item, Transform pos) => spawner.SpawnItem(item, pos);
    //public GameObject SpawnItem(GameObject item, Transform pos) => spawner.SpawnItem(item, pos);
    //public void SpawnItem(Item item, Transform pos) => spawner.SpawnItem(item, pos);
    //public void SpawnItem(Item item, Vector3 pos) => spawner.SpawnItem(item, pos);
    //public List<ItemWorld> SpawnListItems(ItemWorld item, Transform pos, int quantity) => spawner.spawnListItems(item, pos, quantity);
    //public List<GameObject> SpawnListItems(GameObject item, Transform pos, int quantity) => spawner.spawnListItems(item, pos, quantity);


    //public GameObject SpawnWheel(SpawnData spawn, Transform pos) => spawner.SpawnByWheel(spawn, pos);
    //#endregion

}
