using UnityEngine;
using UnityEngine.UI;


public class ProgressBarController : MonoBehaviour
{
    

    [Header("UI Elements")]
    [SerializeField] private Image image;

    [Header("Properties")]
    [SerializeField] private int value;
    [SerializeField] private int maxValue;
    [SerializeField] private bool isCorrectlyConfigured;

    private void Awake()
    {
        if (image.type == Image.Type.Filled & image.fillMethod == Image.FillMethod.Horizontal)
        {
            isCorrectlyConfigured = true;
        }
        else
        {
            Debug.Log(message: "No okay");
        }
        
    }

    private void LateUpdate()
    {
        if (!isCorrectlyConfigured) return;
        image.fillAmount = (float) value / maxValue;
    }

    public void SetValue(int value) => this.value = value;
    public void SetMaxValue(int maxValue) => this.maxValue = maxValue;







}
