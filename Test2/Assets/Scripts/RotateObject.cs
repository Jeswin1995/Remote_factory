using UnityEngine;
using TMPro;

public class RotateObject : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float rotationSpeed = -265f;

    void Update()
    {
        if (text.text != "PR4" && text.text != null)
        {
            float angle = float.Parse(text.text);
            if (angle != null)
            {
                transform.rotation = Quaternion.Euler(0, 180, ((angle / 600f)*-265f));
            }    
        }
        
    }
}
