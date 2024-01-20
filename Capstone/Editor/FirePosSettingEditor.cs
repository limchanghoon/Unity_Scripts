using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FirePosSetting))]
public class FirePosSettingEditor : Editor
{
    FirePosSetting firePosSetting;

    private void OnEnable()
    {
        firePosSetting = (FirePosSetting)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Add FirePos"))
            firePosSetting.SaveLocalPosition();

        firePosSetting.index = EditorGUILayout.IntField("¿Œµ¶Ω∫", firePosSetting.index);
        if (GUILayout.Button("Set localPosition to FirePos"))
            firePosSetting.SetLocalPosition(firePosSetting.index);
    }
}
