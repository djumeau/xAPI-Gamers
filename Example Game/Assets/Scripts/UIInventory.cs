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
       //  Debug.Log("[Start] ... Show List ...");

        inventory = gm.GetInventory();

        if (inventory != null)
            inventory.OnListChangedCallback += UpdateUI;

    }

    void UpdateUI()
    {

        GameObject NewButton = null;

        Debug.Log("[UIInventory/UpdateUI] Inventory count :" + inventory.GetTotalItems());

        if (Prefab == null)
        {
            Debug.LogWarning("Prefab not assigned.");
        } else
        {

            NewButton = Object.Instantiate(Prefab) as GameObject;

            if (NewButton == null)
            {
                Debug.LogWarning("Error: NewButton not created.");

            } else {

                if (itemsParent == null)
                {
                    Debug.LogWarning("Error: itemsParent not assigned.");
                } else
                {
                    NewButton.transform.SetParent(itemsParent, false);
                    originalPosition = NewButton.transform.localPosition;
                    NewButton.SetActive(true);

                    if (ReferenceUI.activeSelf)
                        StartCoroutine(AdjustTransformAtEndOfFrame(NewButton));
                }

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
