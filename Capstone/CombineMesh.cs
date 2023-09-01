using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class CombineMesh : MonoBehaviour
{
    public MeshFilter[] go;

    void Start()
    {
        CombineInstance[] combine = new CombineInstance[go.Length];

        for (int i = 0; i < go.Length; i++)
        {
            combine[i].mesh = go[i].mesh;
            combine[i].transform = go[i].transform.localToWorldMatrix;
        }

        Mesh mesh = this.transform.GetComponent<MeshFilter>().mesh;

        mesh.Clear();
        mesh.CombineMeshes(combine);

        this.gameObject.AddComponent<MeshCollider>();

#if UNITY_EDITOR
        { // Mesh ¿˙¿Â
            string path = "Assets/MyMesh.asset";
            AssetDatabase.CreateAsset(transform.GetComponent<MeshFilter>().mesh, AssetDatabase.GenerateUniqueAssetPath(path));
            AssetDatabase.SaveAssets();
        }
#endif
    }

}