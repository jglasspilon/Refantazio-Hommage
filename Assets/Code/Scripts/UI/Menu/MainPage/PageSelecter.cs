using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageSelecter : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField]
    private bool m_canSelect = true;

    [SerializeField]
    private EMenuPages m_targetPage;   

    [SerializeField]
    private TextMeshPro m_label;

    [SerializeField]
    private GameObject m_selectionSplotch, m_subtitleContainer;

    [SerializeField]
    private Color m_labelColorActive, m_labelColorInactive, m_labelColorDisabled;

    private MainMenuPage m_parentPage;

    public EMenuPages TargetPage {  get { return m_targetPage; } }
    public bool CanSelect {  get { return m_canSelect; } }

    private void Awake()
    {
        m_parentPage = GetComponentInParent<MainMenuPage>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(m_canSelect)
            m_parentPage.SetPageIndex((int)m_targetPage);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(m_canSelect)
            m_parentPage.Confirm();
    }

    public void OnPageIndexChanged(int pageIndex)
    {
        bool isActive = pageIndex == ((int)m_targetPage);

        if (m_canSelect)
            m_label.color = isActive ? m_labelColorActive : m_labelColorInactive;
        else
            m_label.color = m_labelColorDisabled;

        m_selectionSplotch.SetActive(isActive);
        m_subtitleContainer.SetActive(isActive);
    }
}
