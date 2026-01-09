using System;
using UnityEngine;
using UnityEngine.Assertions;

public class ItemController : TriggerController
{
    private static readonly int INVALID_ID = 0;

    [SerializeField] private GameObject m_Item;

    public int UniqueID { get; private set; } = INVALID_ID;

    private void Awake()
    {
        Assert.IsNotNull(m_Item, "Please assign a valid GameObject to the item member.");

        UniqueID = m_Item.GetInstanceID();
    }

    protected override void Interact()
    {
        PickItem();

        CanInteract = false;
    }

    private void PickItem()
    {
        // Store the item into the InventorySystem instance (if available)
        if (InventorySystem.Instance != null)
        {
            InventorySystem.Instance.StoreItem(UniqueID);
        }
        else
        {
            UnityEngine.Debug.LogWarning("InventorySystem instance not found when picking item.");
        }

        // Deactivate the item GameObject if assigned
        if (m_Item != null)
        {
            m_Item.SetActive(false);
        }
        else
        {
            UnityEngine.Debug.LogWarning("Item GameObject is null on ItemController.");
        }
    }
}
