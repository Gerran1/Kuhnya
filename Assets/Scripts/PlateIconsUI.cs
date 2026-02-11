using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField] private PlateKithcenObject plateKithcenObject;
    [SerializeField] private Transform iconTamplate;

    private void Start()
    {
        plateKithcenObject.OnIngredientAdded += PlateKithcenObject_OnIngredientAdded;
    }

    private void PlateKithcenObject_OnIngredientAdded(object sender, PlateKithcenObject.OnIngredientAddedEventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (KitchenObjectSO kitchenObjectSO in plateKithcenObject.GetKitchenObjectSOList())
        {
            Transform iconTransform = Instantiate(iconTamplate, transform);
            iconTamplate.GetComponent<PlateIconsSingleUI>().SetKitchenObjectSO(kitchenObjectSO);
        }
    }

}
