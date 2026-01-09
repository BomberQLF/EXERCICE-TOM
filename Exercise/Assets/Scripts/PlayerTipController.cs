using TMPro;
using UnityEngine;

public class PlayerTipController : MonoBehaviour
{
    [SerializeField] private CanvasGroup m_Container;
    [SerializeField] private TextMeshProUGUI m_Text;

    private void Awake()
    {
        UnityEngine.Assertions.Assert.IsNotNull(m_Container, "PlayerTipController: m_Container is not assigned.");
        UnityEngine.Assertions.Assert.IsNotNull(m_Text, "PlayerTipController: m_Text is not assigned.");

        if (m_Container != null)
            m_Container.alpha = 0f;
    }

    private void Start()
    {
        if (UISystem.Instance != null)
        {
            UISystem.Instance.PlayerTipChanged += OnPlayerTipChanged;
        }
        else
        {
            UnityEngine.Debug.LogWarning("UISystem instance not found. PlayerTipController will not receive tip events.");
        }
    }

    private void OnDestroy()
    {
        if (UISystem.Instance != null)
        {
            UISystem.Instance.PlayerTipChanged -= OnPlayerTipChanged;
        }
    }

    private void OnPlayerTipChanged(UISystem.Tip tip)
    {
        if (m_Text != null)
            m_Text.text = tip.ToString();

        if (m_Container != null)
            m_Container.alpha = tip.IsVisible ? 1f : 0f;
    }
}
