using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ChooseHouse : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private List<GameObject> houses;

    [SerializeField] private TMP_Text houseName;
    [SerializeField] private TMP_Text choosingText;

    GameObject selectedHouse;

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.GetComponent<RawImage>().raycastTarget = false;
        choosingText.gameObject.SetActive(true);

        Debug.Log("Choosing...");
        Invoke(nameof(PlaceHouse), 5f);
    }

    void PlaceHouse()
    {
        for (int i = 0; i < houses.Count; i++)
            selectedHouse = houses[Random.Range(0, houses.Count)];

        selectedHouse.GetComponent<Animation>().Play();       

        choosingText.gameObject.SetActive(false);

        houseName.gameObject.SetActive(true);
        houseName.text = selectedHouse.name + "!";

        Invoke(nameof(DisappearText), 6f);

        Debug.Log(selectedHouse.name);
    }

    void DisappearText()
    {
        houseName.gameObject.SetActive(false);
        gameObject.GetComponent<RawImage>().raycastTarget = true;
    }
}
