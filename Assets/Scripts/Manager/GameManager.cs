using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string MONEY = "money";

    private const string INDEX_GUN = "index for gun";

    private const string INDEX_HERO = "index for hero";

    public static GameManager instance;

    private void Awake()
    {
        MakeInstance();
    }

    public int GetMoney()
    {
        return PlayerPrefs.GetInt(MONEY);
    }

    public void SetMoney(int value)
    {
        PlayerPrefs.SetInt(MONEY, value);
    }

    public int GetIndexGun()
    {
        return PlayerPrefs.GetInt(INDEX_GUN);
    }

    public void SetIndexGun(int value)
    {
        PlayerPrefs.SetInt(INDEX_GUN, value);
    }

    public int GetIndexHero()
    {
        return PlayerPrefs.GetInt(INDEX_HERO);
    }

    public void SetIndexHero(int value)
    {
        PlayerPrefs.SetInt(INDEX_HERO, value);
    }
    void MakeInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }
}