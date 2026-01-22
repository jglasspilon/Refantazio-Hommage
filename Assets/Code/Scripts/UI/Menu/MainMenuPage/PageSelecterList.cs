using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class PageSelecterList : MonoBehaviour
{
    public event Action<int> OnIndexChanged;

    [SerializeField]
    private int m_startPageIndex;

    [SerializeField]
    private Animator m_anim;

    private int m_currentPageIndex;
    private Dictionary<int, PageSelecter> m_pageSelectors;

    private const int MIN_INDEX = 1;

    public int CurrentPageIndex {  get { return m_currentPageIndex; } }

    private void Awake()
    {
        m_pageSelectors = GetComponentsInChildren<PageSelecter>().ToDictionary(x => (int)x.TargetPage, x => x);
        m_currentPageIndex = m_startPageIndex;
    }

    private void OnEnable()
    {
        SetPageIndex(m_currentPageIndex);
    }

    public void CycleUp()
    {
        SetPageIndex(m_currentPageIndex - 1);
    }

    public void CycleDown()
    {
        SetPageIndex(m_currentPageIndex + 1);
    }

    public void SetPageIndex(int pageIndex)
    {
        int newIndex = pageIndex;
        int maxIndex = m_pageSelectors.Count;

        if (newIndex < MIN_INDEX)
            newIndex = maxIndex;

        if (newIndex > maxIndex)
            newIndex = MIN_INDEX;

        m_currentPageIndex = newIndex;
        
        m_anim.SetInteger("PageIndex", m_currentPageIndex);
        OnIndexChanged?.Invoke(m_currentPageIndex);
    }

    public void ResetToDefault()
    {
        SetPageIndex(m_startPageIndex);
    }
}
