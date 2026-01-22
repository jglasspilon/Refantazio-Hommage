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
    private TextMeshProUGUI m_pageIndexText;

    private int m_currentPageIndex;
    private Dictionary<int, PageSelecter> m_pageSelectors;

    private const int MIN_INDEX = 1;

    public int CurrentPageIndex {  get { return m_currentPageIndex; } }

    private void Awake()
    {
        m_pageSelectors = GetComponentsInChildren<PageSelecter>().ToDictionary(x => (int)x.TargetPage, x => x);
    }

    private void Start()
    {
        SetPageIndex(m_startPageIndex);
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
        SetPageText(m_currentPageIndex);
        OnIndexChanged?.Invoke(m_currentPageIndex);
    }

    public void ResetToDefault()
    {
        SetPageIndex(m_startPageIndex);
    }

    private void SetPageText(int pageIndex)
    {
        string result = pageIndex.ToString("0");
        string richTextFix = "";
        float xScale = 1.0f;

        //Manually fix the text size, voffset and xScale based on number since the font sheet used does not have optimal numeral glyph sizing
        switch(pageIndex)
        {
            case 1:
                xScale = 1.4f;
                break;
            case 2:
                break;
            case 3:
            case 4:
            case 5:
            case 7:
            case 9:
                richTextFix = "<size=85%><voffset=80>";
                break;
            case 6:
            case 8:
                richTextFix = "<size=85%><voffset=20>";
                break;
        }

        m_pageIndexText.transform.localScale = new Vector3(xScale, 1, 1);
        m_pageIndexText.text = $"{richTextFix}{result}";
    }
}
