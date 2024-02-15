using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class RatTrapQuest : MonoBehaviour
{
    public float maxDistance = 2f;

    public static int countRatTrap;
    public GameObject interactionIndicator;

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
        countRatTrap++;
        return countRatTrap;
    }
}
