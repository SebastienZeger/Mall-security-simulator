using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoresQuest : MonoBehaviour
{
    [SerializeField] float maxDistance = 2f;
    [SerializeField] GameObject interactionIndicator;
    
    public static int countStore;
    

    void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, maxDistance) && hit.collider.gameObject.CompareTag("DoorStore"))
        {
            
            interactionIndicator.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("DoorClosed");
                hit.collider.enabled = false;
                Count();

            }
        }else
            interactionIndicator.SetActive(false);
    }

    public static int Count()
    {
        countStore++;
        return countStore;
    }
}
