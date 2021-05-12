using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Vector2 dragonSpawnLocation = Vector2.zero;


    private static readonly object padlock = new object();
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }
    }

    public Joystick joystick;

   
    private void Awake()
    {
        instance = this;
        StartGame();
    }

    private void SubscribeEvent()
    {
        Dragon.OnSnakeDied += EndGame;
    }
    private void OnDisable()
    {
        Dragon.OnSnakeDied -= EndGame;
    }

    public void StartGame()
    {
        FindJoystick();
        SubscribeEvent();

        GameObject go = Instantiate(GameAssets.instance.headPrefab, dragonSpawnLocation, Quaternion.identity);
        go.GetComponent<Dragon>().Init();


    }

    private void FindJoystick()
    {
        joystick = FindObjectOfType<Joystick>();
        joystick.gameObject.SetActive(false);
        joystick.gameObject.SetActive(true);
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);

    }


}
