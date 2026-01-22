using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuPage : MenuPage
{
    [SerializeField]
    private PageSelecterList m_pageSelecterList;

    [SerializeField]
    private GameObject m_projectionContent;

    private Menu m_menuParent;

    private void Awake()
    {
        m_menuParent = GetComponentInParent<Menu>();
    }

    private void OnEnable()
    {
        m_pageSelecterList.gameObject.SetActive(true);
        m_projectionContent.SetActive(true);
    }

    private void OnDisable()
    {
        m_pageSelecterList.gameObject.SetActive(false);
        m_projectionContent.SetActive(false);
    }

    public override void CycleUp()
    {
        m_pageSelecterList.CycleUp();
    }

    public override void CycleDown()
    {
        m_pageSelecterList.CycleDown();
    }

    public override void Confirm()
    {
        EMenuPages nextPage = (EMenuPages)m_pageSelecterList.CurrentPageIndex;
        m_menuParent.ChangePageAsync(nextPage);
    }

    public override void ResetPage()
    {
        m_pageSelecterList.ResetToDefault();
    }
}
