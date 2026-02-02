using System;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //не тумбе ничего не лежит
            if (player.HasKitchenObject())
            {
                // у игрока есть в руках объект
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        {
            //на тумбе уже лежит объект
            if (player.HasKitchenObject())
            {
                //у игрока уже есть объект в руках
            }
            else
            {
                //у игрока ничего нет в руках
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }

    }

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject())
        {
            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);

        }
    }
}
