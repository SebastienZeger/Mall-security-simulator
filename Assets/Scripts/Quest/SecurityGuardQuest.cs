using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityGuardQuest : MonoBehaviour
{
    [SerializeField] float maxDistance = 2f;
    [SerializeField] GameObject interactionIndicator;
    
    public static int countGuard;
    
    private bool interact;
    private SecurityGuard _securityGuard;
    
    public Animator AnimatorIA;
    
    public bool _canMove = false;

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

            if (Input.GetKeyDown(KeyCode.E) && !interact)
            {
                StartCoroutine(Wave());
                _securityGuard.enabled = true;
                Count();
                interactionIndicator.SetActive(false);
                interact = true;
            }
        }else
            interactionIndicator.SetActive(false);
    }
    
    public static int Count()
    {
        countGuard = 1;
        return countGuard;
    }

    IEnumerator Wave()
    {
        AnimatorIA.SetBool("Relieve",true);
        yield return new WaitForSeconds(2f);
        AnimatorIA.SetBool("Relieve",false);
        _canMove = true;

    }
}
