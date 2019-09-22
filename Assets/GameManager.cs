using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Singleton
    private static GameManager instance;

    //UI
    [Header("UI components")]
    [SerializeField]
    private Text goldAmountText;
    [SerializeField]
    private Text woodAmountText;

    [Space]
    [SerializeField]
    private RawImage unitImageUI;
    [SerializeField]
    private Text unitNameUI;
    [SerializeField]
    private GameObject unitHealthPanel;
    [SerializeField]
    private Text unitHealthBarText;

    //Resources
    [Space]
    [Header("Player Resources")]
    [SerializeField]
    private int gold;
    [SerializeField]
    private int wood;

    //Unit Control
    [Space]
    public Unit selectedUnit;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (selectedUnit != null)
        {
            unitImageUI.texture = selectedUnit.unitSprite;
            unitNameUI.text = selectedUnit.unitName;

            unitHealthBarText.text = selectedUnit.GetCurrentHealth() + " / " + selectedUnit.MaxHealth;
        }

        goldAmountText.text = gold.ToString();
        woodAmountText.text = wood.ToString();
    }

    public void SelectUnit(Unit unit)
    {
        selectedUnit = unit;

        unitImageUI.texture = selectedUnit.unitSprite;
        unitNameUI.text = selectedUnit.unitName;
    }

    public void ResetUnitSelection()
    {
        selectedUnit = null;

        unitImageUI.texture = null;
        unitNameUI.text = null;
        unitHealthBarText.text = null;
    }

    public void AwardResources(int _gold, int _wood)
    {
        gold += _gold;
        wood += _wood;

        if (gold < 0) gold = 0;
        if (wood < 0) wood = 0;
    }

    public static GameManager GetInstance()
    {
        return instance;
    }
    private GameManager()
    { }
}