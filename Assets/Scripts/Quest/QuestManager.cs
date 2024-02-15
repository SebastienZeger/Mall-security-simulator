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

    private bool _bRatTrap = true;
    private bool _bToilette = true;
    private bool _bStore = true;
    private void Update()
    {
        RatTrapQuestCount();
        ToiletteQuestCount();
        StoreQuestCount();
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
            _bRatTrap = true;
        }
    }

    public void ToiletteQuestCount()
    {
        if (ToiletteQuest.countToilette == 1 && _bToilette)
        {
            toiletteTextQuest.text = "1/1";
            _bToilette = false;
        }
    }

    public void StoreQuestCount()
    {
        if (StoresQuest.countStore == 1 && _bStore)
        {
            storeTextQuest.text = "1/5";
            _bStore = false;
        }
        else if (StoresQuest.countStore == 2 && !_bStore)
        {
            storeTextQuest.text = "2/5";
            _bStore = true;
        }
        else if (StoresQuest.countStore == 3 && _bStore)
        {
            storeTextQuest.text = "3/5";
            _bStore = false;
        }
        else if (StoresQuest.countStore == 4 && !_bStore)
        {
            storeTextQuest.text = "4/5";
            _bStore = true;
        }
        else if (StoresQuest.countStore == 5 && _bStore)
        {
            storeTextQuest.text = "5/5";
            _bStore = false;
        }
        
    }
}
