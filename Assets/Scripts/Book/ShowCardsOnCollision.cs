using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    [Header("Configurações")]
    [SerializeField] private GameObject canvasUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Colidiu com o Player!");
            Time.timeScale = 0f;

            gameObject.SetActive(false);

            if (canvasUI != null)
            {
                canvasUI.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Canvas UI não está atribuído no Inspector!");
            }
        }
    }
}