using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PlaySound : MonoBehaviour, IPointerClickHandler
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private Button thisButton;
    private TMP_Text thisText;

    private GameObject[] buttons;

    private float audioLength;

    void Start()
    {
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();

        buttons = GameObject.FindGameObjectsWithTag("AudioButton");

        thisButton = gameObject.GetComponent<Button>();
        thisText = gameObject.GetComponentInChildren<TMP_Text>();

        audioLength = audioClip.length;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        thisButton.onClick.RemoveAllListeners();

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().image.color = Color.white;
            buttons[i].GetComponentInChildren<TMP_Text>().color = Color.white;
        }

        thisButton.image.color = Color.red;
        thisText.color = Color.red;

        audioSource.clip = audioClip;
        audioSource.Play();

        Invoke(nameof(SetDefaultSettings), audioLength);
    }

    void SetDefaultSettings()
    {
        thisButton.image.color = Color.white;
        thisText.color = Color.white;
    }
}