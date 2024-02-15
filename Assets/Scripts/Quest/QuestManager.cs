using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ratTextQuest;
    [SerializeField] private TextMeshProUGUI toiletteTextQuest;
    [SerializeField] private TextMeshProUGUI storeTextQuest;
    [SerializeField] private TextMeshProUGUI guardTextQuest;
    
    [SerializeField] private TextMeshProUGUI ratTextQuestGlitch;
    [SerializeField] private TextMeshProUGUI toiletteTextQuestGlitch;
    [SerializeField] private TextMeshProUGUI storeTextQuestGlitch;

    private bool _bRatTrap = true;
    private bool _bToilette = true;
    private bool _bStore = true;
    private bool _bGuard = true;
    

    private const string boolKeyToilette = "Toilette";
    private const string boolKeyStore = "Store";
    private const string boolKeyRatTrap = "RatTrap";

    public const string boolEndKeyStore = "EndStore";
    public const string boolEndKeyToilette = "EndToilette";
    public const string boolEndKeyRatTrap = "EndRatTrap";


    private static bool defaultsInitialized = false;

    private void Awake()
    {
        
        if (!defaultsInitialized)
        {
            InitializeDefaults();
            defaultsInitialized = true;
        }
        
        if (LoadBool(boolKeyRatTrap))
        {
            ratTextQuestGlitch.text = "Check the bear trap";
            ratTextQuest.text = "";
        }
        
        if (LoadBool(boolKeyStore))
        {
            storeTextQuestGlitch.text = "Check that the 8 stores are closed :";
            storeTextQuest.text = "0/8";
        }
        
        if (LoadBool(boolKeyToilette))
        {
            toiletteTextQuestGlitch.text = "Check that the toilets are not stuck in no one";
            toiletteTextQuest.text = "";
        }
    }

    private void Update()
    {
        RatTrapQuestCount();
        ToiletteQuestCount();
        StoreQuestCount();
        GuardQuestCount();
    }

    public void RatTrapQuestCount()
    {
        if (RatTrapQuest.countRatTrap == 1 && _bRatTrap)
        {
            ratTextQuest.text = "1/2";
            _bRatTrap = false;
        }else if (RatTrapQuest.countRatTrap == 2 && !_bRatTrap)
        {
            ratTextQuest.text = "2/2";
            SaveBool(boolKeyRatTrap, true);
            SaveBool(boolEndKeyRatTrap, true);
            _bRatTrap = true;
        }
    }

    public void ToiletteQuestCount()
    {
        if (ToiletteQuest.countToilette == 1 && _bToilette)
        {
            toiletteTextQuest.text = "1/1";
            SaveBool(boolKeyToilette, true);
            SaveBool(boolEndKeyToilette, true);
            _bToilette = false;
        }
    }
    
    public void GuardQuestCount()
    {
        if (SecurityGuardQuest.countGuard == 1 && _bGuard)
        {
            guardTextQuest.text = "1/1";
            _bGuard = false;
        }
    }

    public void StoreQuestCount()
    {
        if (StoresQuest.countStore == 1 && _bStore)
        {
            if (LoadBool(boolEndKeyStore))
            {
                storeTextQuest.text = "1/8";
                _bStore = false;
            }
            else
            {
                storeTextQuest.text = "1/5";
                _bStore = false; 
            }
        }
        else if (StoresQuest.countStore == 2 && !_bStore)
        {
            if (LoadBool(boolEndKeyStore))
            {
                storeTextQuest.text = "2/8";
                _bStore = true;
            }
            else
            {
                storeTextQuest.text = "2/5";
                _bStore = true; 
            }
        }
        else if (StoresQuest.countStore == 3 && _bStore)
        {
            if (LoadBool(boolEndKeyStore))
            {
                storeTextQuest.text = "3/8";
                _bStore = false;
            }
            else
            {
                storeTextQuest.text = "3/5";
                _bStore = false; 
            }
        }
        else if (StoresQuest.countStore == 4 && !_bStore)
        {
            if (LoadBool(boolEndKeyStore))
            {
                storeTextQuest.text = "4/8";
                _bStore = true;
            }
            else
            {
                storeTextQuest.text = "4/5";
                _bStore = true; 
            }
        }
        else if (StoresQuest.countStore == 5 && _bStore)
        {
            if (LoadBool(boolEndKeyStore))
            {
                storeTextQuest.text = "5/8";
                _bStore = false;
            }
            else
            {
                storeTextQuest.text = "5/5";
                SaveBool(boolKeyStore, true);
                _bStore = true;
                SaveBool(boolEndKeyStore, true);
            }
        }
    }
    
    public static void InitializeDefaults()
    {
        
        PlayerPrefs.SetInt(boolKeyToilette, 0);
        PlayerPrefs.SetInt(boolKeyStore, 0);
        PlayerPrefs.SetInt(boolKeyRatTrap, 0);

        PlayerPrefs.SetInt(boolEndKeyStore, 0);
        PlayerPrefs.SetInt(boolEndKeyToilette, 0);
        PlayerPrefs.SetInt(boolEndKeyRatTrap, 0);
        PlayerPrefs.Save();
    }

    public static void SaveBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key,value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static bool LoadBool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1;
    }
}
