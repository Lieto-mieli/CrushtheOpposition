using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

    public GameObject tooltip;
    // Update is called once per frame
    public void OnPointerEnter(PointerEventData datashittis)
    {
        tooltip.SetActive(true);
    }
    public void OnPointerExit(PointerEventData datashittis)
    {
        tooltip.SetActive(false);
    }
}
