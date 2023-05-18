using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnumList))]
public class EnumListEditor : Editor
{
    private SerializedProperty enumList;

    private void OnEnable()
    {
        enumList = serializedObject.FindProperty("enumValues");
    }

    //public override void OnInspectorGUI()
    //{
    //    base.OnInspectorGUI();

    //    EnumList enumObject = (EnumList)target;

    //    if (GUILayout.Button("Ekle"))
    //    {
    //        string newEnumValue = EditorGUILayout.TextField("Yeni Deðer Ekle", "");

    //        if (!string.IsNullOrEmpty(newEnumValue) && !enumObject.enumValues.Contains(newEnumValue))
    //        {
    //            enumObject.enumValues.Add(newEnumValue);
    //            enumObject.UpdateEnumNames();
    //        }
    //    }

    //    EditorGUILayout.LabelField("Enum Degerleri:");

    //    EditorGUI.indentLevel++;
    //    for (int i = 0; i < enumObject.MyEnumNames.Length; i++)
    //    {
    //        enumObject.MyEnumNames[i] = EditorGUILayout.TextField(enumObject.MyEnumNames[i]);

    //        if (!enumObject.enumValues.Contains(enumObject.MyEnumNames[i]))
    //        {
    //            enumObject.enumValues.Add(enumObject.MyEnumNames[i]);
    //            enumObject.UpdateEnumNames();
    //        }
    //    }
    //    EditorGUI.indentLevel--;

    //    serializedObject.ApplyModifiedProperties();
    //}



}
