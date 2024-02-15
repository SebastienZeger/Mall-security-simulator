using System.Collections;
using TMPro;
using UnityEngine;

public class PadCode : MonoBehaviour
{
    [SerializeField] private string saisi;
    [SerializeField] private string code = "0000";
    [SerializeField] private GameObject pinPad;
    [SerializeField] private int maxString = 4;
    [SerializeField] private TextMeshProUGUI codeText;
    [SerializeField] private GameObject door;
    
    [SerializeField] private AudioClip ButtonClip;
    [SerializeField] private AudioClip SucessClip;
    [SerializeField] private AudioClip NoSucessClip;
    private AudioSource _audioSource;
    
    public static bool sucess = false;

    private bool _resetSaisi;

    private InteractPad _interactPad;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _interactPad = FindObjectOfType<InteractPad>();
    }
    
    void Update()
    {
        if (saisi.Length < maxString)
        {
            switch (PadButton.numbt)
                    {
                        case 1 :
                            saisi = saisi + "1";
                            PadButton.numbt = 12;
                            _audioSource.PlayOneShot(ButtonClip);
                            break;
                        case 2 :
                            saisi = saisi + "2";
                            PadButton.numbt = 12;
                            _audioSource.PlayOneShot(ButtonClip);
                            break;
                        case 3 :
                            saisi = saisi + "3";
                            PadButton.numbt = 12;
                            _audioSource.PlayOneShot(ButtonClip);
                            break;
                        case 4 :
                            saisi = saisi + "4";
                            PadButton.numbt = 12;
                            _audioSource.PlayOneShot(ButtonClip);
                            break;
                        case 5 :
                            saisi = saisi + "5";
                            PadButton.numbt = 12;
                            _audioSource.PlayOneShot(ButtonClip);
                            break;
                        case 6 :
                            saisi = saisi + "6";
                            PadButton.numbt = 12;
                            _audioSource.PlayOneShot(ButtonClip);
                            break;
                        case 7 :
                            saisi = saisi + "7";
                            PadButton.numbt = 12;
                            _audioSource.PlayOneShot(ButtonClip);
                            break;
                        case 8 :
                            saisi = saisi + "8";
                            PadButton.numbt = 12;
                            _audioSource.PlayOneShot(ButtonClip);
                            break;
                        case 9 :
                            saisi = saisi + "9";
                            PadButton.numbt = 12;
                            _audioSource.PlayOneShot(ButtonClip);
                            break;
                        case 0 :
                            saisi = saisi + "0";
                            PadButton.numbt = 12;
                            _audioSource.PlayOneShot(ButtonClip);
                            break;
                        
                        default:
                            break;
                    }   
        
        }
        codeText.text = saisi;

    }

    private void FixedUpdate()
    {
        if (_resetSaisi)
        {
            saisi = "";
            _resetSaisi = false;
        }
    }

    public void ExecuteCode()
    {
        if (saisi == code)
        {
            _audioSource.PlayOneShot(SucessClip);
            sucess = true;
            pinPad.SetActive(true);
            codeText.color = Color.green;
            openDoor();
            _interactPad.GetComponent<InteractPad>().GoodPin();
            
        }
        else if (saisi != code)
        {
            _audioSource.PlayOneShot(NoSucessClip);
            StartCoroutine(NoSucessDoor());
        }
    }

    void openDoor()
    {
        Destroy(door);
    }

    IEnumerator NoSucessDoor()
    {
        codeText.color = Color.red;
        yield return new WaitForSeconds(0.8f);
        saisi = "";
        codeText.color = Color.black;
        _resetSaisi = true;
    }
}
