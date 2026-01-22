using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageSelecter : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField]
    private EMenuPages m_targetPage;

    [SerializeField]
    private TextMeshPro m_label;

    [SerializeField]
    private GameObject m_selectionSplotch, m_subtitleContainer;

    [SerializeField]
    private Color m_labelColorActive, m_labelColorInactive;

    private PageSelecterList m_listParent;
    private MenuPage m_parentPage;

    public EMenuPages TargetPage {  get { return m_targetPage; } }

    private void Awake()
    {
        m_listParent = GetComponentInParent<PageSelecterList>();
        m_parentPage = GetComponentInParent<MenuPage>();
    }

    private void OnEnable()
    {
        m_listParent.OnIndexChanged += OnPageIndexChanged;
    }

    private void OnDisable()
    {
        m_listParent.OnIndexChanged -= OnPageIndexChanged;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_listParent.SetPageIndex((int)m_targetPage);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        m_parentPage.Confirm();
    }

    private void OnPageIndexChanged(int pageIndex)
    {
        bool isActive = pageIndex == ((int)m_targetPage);
        m_label.color = isActive ? m_labelColorActive : m_labelColorInactive;
        m_selectionSplotch.SetActive(isActive);
        m_subtitleContainer.SetActive(isActive);
    }
}
