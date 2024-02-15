using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractGuard : MonoBehaviour
{
    [SerializeField] float maxDistance = 2f;
    [SerializeField] GameObject interactionIndicator;
    
    private bool interact;

    private SecurityGuard _securityGuard;

    private void Start()
    {
        _securityGuard = FindObjectOfType<SecurityGuard>();
    }

    void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, maxDistance) && hit.collider.gameObject.CompareTag("SecurityGuard"))
        {
            if (!interact)
            {
                interactionIndicator.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                _securityGuard.enabled = true;
                interactionIndicator.SetActive(false);
                interact = true;
            }
        }else
            interactionIndicator.SetActive(false);
    }
}
