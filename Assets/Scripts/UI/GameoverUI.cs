using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class GameoverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipiesDeliveredText;

    private void Start()
    {
        KitchenGameManager.Instance.OnStateChanged += Instance_OnStateChanged;
    }

    private void Instance_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.IsGameOver())
        {
            Show();

            recipiesDeliveredText.text = DeliveryManager.Instance.GetSuccesfulRecipiesAmount().ToString();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
