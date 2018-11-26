using UnityEngine;
using System.Collections;

public class UIInventory : MonoBehaviour {

    private GameManager gm;
    private Inventory inventory;

    [SerializeField]
    private GameObject ReferenceUI; // Points to Inventory UI Canvas

    public GameObject Prefab;
    public Transform itemsParent;

    private Vector2 originalPosition;

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Use this for initialization
    void Start () {
       
        inventory = gm.GetInventory();

        if (inventory != null)
            inventory.OnListChangedCallback += UpdateUI;

        Debug.Log("[Start] ... Show List ...");
        UpdateUI();

    }

    void UpdateUI()
    {

        Debug.Log("[UIInventory/UpdateUI] Inventory count :" + inventory.GetTotalItems());

        if (Prefab == null)
        {
            Debug.LogWarning("Prefab not assigned.");
        } else
        {
            //Find out how many children...

            if (inventory.GetTotalItems() != itemsParent.childCount)
            {

            }

            Debug.Log("# of children [" + itemsParent.childCount + "]");

            // AddItemButton();

        }
               
    }

    private void AddItemButton(int ItemId)
    {
        if (ItemId != null)
            Debug.Log("Add Button [" + ItemId + "]");

        GameObject NewButton = null;

        NewButton = Object.Instantiate(Prefab) as GameObject;

        if (NewButton == null)
        {
            Debug.LogWarning("Error: NewButton not created.");

        }
        else
        {

            Debug.Log("ItemsParent [" + "]");

            if (itemsParent == null)
            {
                Debug.LogWarning("Error: itemsParent not assigned.");
            }
            else
            {
                // Need reference to ItemButton
                ItemButton btn = NewButton.GetComponent<ItemButton>();

                if (btn != null)
                {
                    //Assign Item data to Button
                    Item ItemObject = inventory.GetLastInventoryItem();
                    btn.UpdateButton(ItemObject);
                }
                else
                {
                    Debug.LogWarning("Reference to ItemButton not found.");
                }


                NewButton.transform.SetParent(itemsParent, false);
                originalPosition = NewButton.transform.localPosition;
                NewButton.SetActive(true);

                if (ReferenceUI.activeSelf)
                    StartCoroutine(AdjustTransformAtEndOfFrame(NewButton));
            }

        }
    }

    private IEnumerator AdjustTransformAtEndOfFrame(GameObject someGameObject)
    {
        yield return new WaitForEndOfFrame();
        someGameObject.transform.localPosition = originalPosition;
        someGameObject.SetActive(true);
    }
    
}
