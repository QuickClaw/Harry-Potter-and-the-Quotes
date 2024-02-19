using UnityEngine;
using UnityEngine.EventSystems;

public class PanelNavigation : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject thisPanel;
    [SerializeField] private GameObject nextPanel;
    [SerializeField] private GameObject previousPanel;

    [SerializeField] private GameObject mainPanel;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.Find("ClickAudioSource").GetComponent<AudioSource>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.Play();

        thisPanel.SetActive(false);
        nextPanel.SetActive(true);
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (mainPanel.activeInHierarchy)
                    Application.Quit();
                else
                {
                    audioSource.Play();

                    thisPanel.SetActive(false);
                    previousPanel.SetActive(true);
                }
            }
        }
    }
}