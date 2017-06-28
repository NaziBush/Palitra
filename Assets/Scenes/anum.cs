using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anum : MonoBehaviour
{
    MeshFilter filter;
    public Mesh[] meshes;
    public GameObject[] m;
    int i = 0;
	
	void Start ()
    {
        filter = GetComponent<MeshFilter>();
        StartCoroutine(cor());
	}
	
	IEnumerator cor()
    {
        while(true)
        {
            Mesh mesh = m[i].transform.GetChild(0).GetChild(0).
                gameObject.GetComponent<MeshFilter>().sharedMesh;
            filter.mesh = mesh;
            i++;
            if (i == m.Length)
                i = 0;
            yield return new WaitForSeconds(0.1f);
            //filter.mesh = meshes[i];
            //i++;
            //if (i == meshes.Length)
            //    i = 0;
            //yield return new WaitForSeconds(0.1f);
        }
    }
}
