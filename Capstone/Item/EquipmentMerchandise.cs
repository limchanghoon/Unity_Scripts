using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentMerchandise : MonoBehaviour
{
    [SerializeField] int m_Id;
    [SerializeField] string m_ItemName;
    public int m_Part;
    [SerializeField] int m_Level;
    [SerializeField] int m_AorD;

    public Equipment_ItemData equipment_ItemData;

    private void Start()
    {
        if(m_Part == 0)
        {
            equipment_ItemData = new Weapon_ItemData(string.Empty, m_Id, m_ItemName, m_Part, m_Level, m_AorD);
        }
        else
        {
            equipment_ItemData = new Armor_ItemData(string.Empty, m_Id, m_ItemName, m_Part, m_Level, m_AorD);
        }
    }
}
