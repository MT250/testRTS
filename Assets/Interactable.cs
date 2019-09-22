using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    [SerializeField] private Type objectType;
    
    [Header("Behaviour")]
    public bool rotate;
    public Vector3 rotation;

    [Header("Item Type Bonuses")]
    public int goldBonus;
    public int woodBonus;

    [Header("Resource Node Params")]
    public int goldAmount;
    public int woodHealth;

    void FixedUpdate()
    {
        if (rotate) transform.Rotate(rotation * Time.deltaTime, Space.World);
    }

    public void Activate(Unit interactedUnit)
    {
        if (objectType == Type.Item)
        {
            GameManager instance = GameManager.GetInstance();
            instance.AwardResources(goldBonus, woodBonus);
            gameObject.SetActive(false);
        }
        Debug.Log("Activated!");
    }

    private enum Type
    { Item, ResourceNode }
}



