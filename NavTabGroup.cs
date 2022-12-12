using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavTabGroup : MonoBehaviour
{
    public PageControl pages;
    public List<NavTabButton> tabButtons;
    NavTabButton selectedButton;

    public void Sucscribe(NavTabButton button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<NavTabButton>();
        }
        tabButtons.Add(button);
        if(button.IsDefault)
        {
            OnTabSelected(button);
        }
    }

    public void OnTabEnter(NavTabButton button)
    {
        button.bg.sprite = button.spriteSelected;
    }

    public void OnTabSelected(NavTabButton button)
    {
        if(selectedButton != null && selectedButton != button)
        {
            selectedButton.bg.sprite = selectedButton.spriteIdle;
            if(selectedButton.onTabDeselected != null)
            {
                selectedButton.onTabDeselected.Invoke();
            }
        }

        int index = button.transform.GetSiblingIndex();
        if (selectedButton != button)
        {
            if(button.onTabSelected != null)
            {
                button.onTabSelected.Invoke();
            }
            button.bg.sprite = button.spriteSelected;
            selectedButton = button;
            pages.JumpToPage(index);
        }
        else if (selectedButton == button && !pages.IsCurrentPage(index))
        {
            pages.JumpToPage(index);
        }
    }

    public void OnTabExit(NavTabButton button)
    {
        if(selectedButton != button)
        {
            button.bg.sprite = button.spriteIdle;
        }
    }
}
