using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateSmoothingGroup : MonoBehaviour
{
    Mesh mesh;

    [ContextMenu("Create")]
    public void Create()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        Dictionary<Vector3, List<int>> map = new Dictionary<Vector3, List<int>>();

        for(int v = 0; v < mesh.vertexCount; ++v)
        {
            if (!map.ContainsKey(mesh.vertices[v]))
            {
                map.Add(mesh.vertices[v], new List<int>());
            }

            map[mesh.vertices[v]].Add(v);
        }

        Vector3[] normals = mesh.normals;
        Vector3 normal;

        foreach(var p in map)
        {
            normal = Vector3.zero;

            foreach(var n in p.Value)
            {
                normal += mesh.normals[n];
            }

            normal /= p.Value.Count;

            foreach(var n in p.Value)
            {
                normals[n] = normal;
            }
        }

        mesh.normals = normals;

        // Mesh ¿˙¿Â
        //string path = "Assets/Meshs/MyMesh.asset";
        //AssetDatabase.CreateAsset(mesh, AssetDatabase.GenerateUniqueAssetPath(path));
        //AssetDatabase.SaveAssets();
    }
}
