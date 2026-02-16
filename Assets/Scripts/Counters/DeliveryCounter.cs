using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            if (player.GetKitchenObject().TryGetPlate(out PlateKithcenObject plateKithcenObject))
            {
                DeliveryManager.Instance.DeliveryRecipe(plateKithcenObject);

                player.GetKitchenObject().DestroySelf();
            }
        }
    }
}
