using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject _toiletteLight;
    [SerializeField] Toggle toggle;
    
    
    public void ToggleObjectActivation()
    {
        if (toggle.isOn)
        {
            _toiletteLight.SetActive(true);
        }
        else if (!toggle.isOn)
        {
            _toiletteLight.SetActive(false);
        }
    }
}
