using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class RatTrapQuest : MonoBehaviour
{
    [SerializeField] float maxDistance = 2f;
    [SerializeField] GameObject interactionIndicator;

    public static int countRatTrap;
    

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, maxDistance) && hit.collider.gameObject.CompareTag("RatTrap"))
        {
            
            interactionIndicator.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Rat");
                hit.collider.enabled = false;
                Count();

            }
        }else
            interactionIndicator.SetActive(false);
    }

    public static int Count()
    {
        if (QuestManager.LoadBool(QuestManager.boolEndKeyRatTrap))
        {
            countRatTrap = 0;
        }
        else
        {
            countRatTrap++;
        }
        return countRatTrap;
    }
}
