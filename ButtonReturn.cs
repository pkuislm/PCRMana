using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReturn : MonoBehaviour
{
    public void OnReturnClicked()
    {
        var pc = Singleton<PageControl>.Instance;
        pc.ReturnToPreviousPage();
    }
}
