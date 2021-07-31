using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGroup : MonoBehaviour
{
    public GameObject[] panels;
    public TabGroup tabGroup;
    public int panelInex;

    private void Awake()
    {
        showCurrentPanel();
    }
    void showCurrentPanel()
    {
        for(int i = 0; i < panels.Length; i++)
        {
            if(i == panelInex)
            {
                panels[i].gameObject.SetActive(true);
            }
            else
            {
                panels[i].gameObject.SetActive(false);
            }
        }
    }
    public void setPageIndex(int index)
    {
        panelInex = index;
        showCurrentPanel();

    }
}
