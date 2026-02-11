using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenObjectSO_GameObject
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }

    [SerializeField] private PlateKithcenObject platekitchenObject;
    [SerializeField] private List<KitchenObjectSO_GameObject> kitchenObjectSOGameObjectList;

    private void Start()
    {
        platekitchenObject.OnIngredientAdded += PlatekitchenObject_OnIngredientAdded;

        foreach (KitchenObjectSO_GameObject ingredient in kitchenObjectSOGameObjectList)
        {
            ingredient.gameObject.SetActive(false);
        }
    }

    private void PlatekitchenObject_OnIngredientAdded(object sender, PlateKithcenObject.OnIngredientAddedEventArgs e)
    {
        foreach (KitchenObjectSO_GameObject ingredient in kitchenObjectSOGameObjectList)
        {
            if(ingredient.kitchenObjectSO == e.kitchenObjectSO)
            {
                ingredient.gameObject.SetActive(true);
            }
            
        }
    }
}
