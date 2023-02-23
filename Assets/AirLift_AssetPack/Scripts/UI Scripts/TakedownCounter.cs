using UnityEngine;
using UnityEngine.UI;

public class TakedownCounter : MonoBehaviour
{
    public int takedownCount = 0;
    public Text takedownText;

    void Start()
    {
        takedownText = GetComponent<Text>();
       
    }

    
    public void UpdateTakedownCount()
    {
        takedownText.text =takedownCount.ToString();
    }

    public void AddTakedown()
    {
        takedownCount++;
        UpdateTakedownCount();
    }

    public void ResetTakedownCount()
    {
        takedownCount = 0;
        UpdateTakedownCount();
    }
}
