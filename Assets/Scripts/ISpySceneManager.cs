using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ISpySceneManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    Transform DragContainer;
    [SerializeField]
    Sprite[] ItemSprites;
    [SerializeField]
    string[] ItemTitles;
    [SerializeField]
    string[] ItemDescriptions;
    [SerializeField]
    Image PopupImage;
    [SerializeField]
    TextMeshProUGUI PopupTitle;
    [SerializeField]
    TextMeshProUGUI PopupDescription;
    [SerializeField]
    GameObject Popup;

    private float lastDragPos;
    [SerializeField]
    float minX = -3020f;
    float maxX = 0;
    float scaleFactor;

    // Start is called before the first frame update
    void Start()
    {
        scaleFactor = this.GetComponent<Canvas>().scaleFactor;
        maxX = 0;
        minX = minX * scaleFactor;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastDragPos = eventData.position.x;
    }

    // Drag the selected item.
    public void OnDrag(PointerEventData data)
    {
        float dragOffset = lastDragPos - data.position.x;
        lastDragPos = data.position.x;
        float newX = DragContainer.position.x - dragOffset;
        newX = Mathf.Max(minX, newX);
        newX = Mathf.Min(maxX, newX);
        DragContainer.position = new Vector3(newX, DragContainer.position.y, DragContainer.position.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("OnEndDrag: " + eventData.position.x);
    }

    public void DisplayPopupItem(int itemNum)
    {
        PopupImage.sprite = ItemSprites[itemNum];
        PopupTitle.text = ItemTitles[itemNum];
        PopupDescription.text = ItemDescriptions[itemNum];
        Popup.transform.localScale = new Vector3(.1f, .1f, .1f);
        Popup.SetActive(true);
        Popup.GetComponent<GrowAndShrink>().StartEffect();

    }
}
