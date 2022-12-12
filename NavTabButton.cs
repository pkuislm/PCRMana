using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class NavTabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public Image bg;
    public Sprite spriteIdle;
    public Sprite spriteSelected;
    public NavTabGroup tabgroup;
    public bool IsDefault;
    public UnityEvent onTabSelected;
    public UnityEvent onTabClicked;
    public UnityEvent onTabDeselected;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabgroup.OnTabSelected(this);
        if(onTabClicked != null)
        {
            onTabClicked.Invoke();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabgroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabgroup.OnTabExit(this);

    }

    // Start is called before the first frame update
    void Start()
    {
        bg = GetComponent<Image>();
        tabgroup.Sucscribe(this);
    }

}
