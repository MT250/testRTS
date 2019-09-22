using UnityEngine;
using UnityEngine.UI;

public class UnitResourceIcon : MonoBehaviour
{
    [SerializeField] private Image resourceIconGold;
    [SerializeField] private Image resourceIconWood;

    [SerializeField] private Text resourceCarryAmount;

    void Update()
    {
        LookAtCamera();
    }

    private void LookAtCamera()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }

    public void DisplayAmount(float _gold, float _wood)
    {
        if (_gold == 0 && _wood == 0)
        {
            resourceCarryAmount.text = "";
            resourceIconGold.gameObject.SetActive(false);
            resourceIconWood.gameObject.SetActive(false);
        }
        else if (_gold > 0)
        {
            resourceIconGold.gameObject.SetActive(true);
            resourceCarryAmount.color = Color.yellow;
            resourceCarryAmount.text = _gold.ToString();
        }
        else if (_wood > 0)
        {
            resourceIconWood.gameObject.SetActive(true);
            resourceCarryAmount.color = Color.green;
            resourceCarryAmount.text = _wood.ToString();
        }
    }
}
