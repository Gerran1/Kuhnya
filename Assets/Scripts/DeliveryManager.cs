using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance {  get; private set; }

    [SerializeField] 
    private RecipeListSO recipeListSO;

    private List<RecipeSO> waitingRecipeSOList;
    private float spawnRecipeTimer;
    private float spawnRecipeTimerMax = 4f;
    private int waitingRecipesMax = 4;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("DeliveryManager already has an Instance");
        }

        waitingRecipeSOList = new List<RecipeSO>();
    }

    private void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;
        if (spawnRecipeTimer <= 0f)
        {
            spawnRecipeTimer = spawnRecipeTimerMax;

            if (waitingRecipeSOList.Count < waitingRecipesMax)
            {
                RecipeSO waitingRecipeSO = recipeListSO.recipeSOList[Random.Range(0, recipeListSO.recipeSOList.Count)];
                Debug.Log(waitingRecipeSO.recipeName);
                waitingRecipeSOList.Add(waitingRecipeSO);
            }
        }
    }

    public void DeliveryRecipe(PlateKithcenObject plateKithcenObject)
    {
        for (int i = 0; i < waitingRecipeSOList.Count; i++)
        {
            RecipeSO waitingRecipeSO = waitingRecipeSOList[i];

            if (waitingRecipeSO.kitchenObjectSOList.Count == plateKithcenObject.GetKitchenObjectSOList().Count)
            {
                bool platesContentsMatchesRecipe = true;
                // количество ингредиенты совпадают
                foreach (KitchenObjectSO kitchenObjectSO in waitingRecipeSO.kitchenObjectSOList)
                {
                    bool ingredientFound = false;
                    //пробежимся по всем ингредиентам в рецепте
                    foreach (KitchenObjectSO plateKitchenObjectSO in plateKithcenObject.GetKitchenObjectSOList())
                    {
                        // пробегаемся по всем ингредиентам в тарелке
                        if (plateKitchenObjectSO == kitchenObjectSO)
                        {
                            // ингердиенты совпали!!!
                            ingredientFound = true;
                            break;
                        }
                    }
                    if (!ingredientFound)
                    {
                        // ингредиенты рецепта не был найден на тарелке
                        platesContentsMatchesRecipe = false;
                    }
                }
                if (platesContentsMatchesRecipe)
                {
                    Debug.Log("Игрок доставил нужный рецепт");
                    waitingRecipeSOList.RemoveAt(i);
                    return;
                }
            }
        }
        //совпадений не найдено
        //игрок доставио не тот рецепт
        Debug.Log("Игрок доставил не тот рецепт!");
    }

    public List<RecipeSO> GetWaitingRecipeSOList()
    {
        return waitingRecipeSOList;
    }
}
