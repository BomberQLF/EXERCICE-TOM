using TMPro;
using UnityEngine;

public class PlayerWarningController : MonoBehaviour
{
    [SerializeField] private CanvasGroup m_Container;
    [SerializeField] private TextMeshProUGUI m_Text;

    private void Awake()
    {
        UnityEngine.Assertions.Assert.IsNotNull(m_Container, "PlayerWarningController: m_Container is not assigned.");
        UnityEngine.Assertions.Assert.IsNotNull(m_Text, "PlayerWarningController: m_Text is not assigned.");

        if (m_Container != null)
            m_Container.alpha = 0f;
    }

    private void Start()
    {
        if (UISystem.Instance != null)
        {
            UISystem.Instance.PlayerWarningChanged += OnPlayerWarningChanged;
        }
        else
        {
            UnityEngine.Debug.LogWarning("UISystem instance not found. PlayerWarningController will not receive warning events.");
        }
    }

    private void OnDestroy()
    {
        if (UISystem.Instance != null)
        {
            UISystem.Instance.PlayerWarningChanged -= OnPlayerWarningChanged;
        }
    }

    private void OnPlayerWarningChanged(UISystem.Tip tip)
    {
        if (m_Text != null)
            m_Text.text = tip.ToString();

        if (m_Container != null)
            m_Container.alpha = tip.IsVisible ? 1f : 0f;
    }
}
