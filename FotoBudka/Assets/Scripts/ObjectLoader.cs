using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityMeshImporter
;


public class ObjectLoader : MonoBehaviour
{
    int currentChild =0;
    public List<GameObject> allChildren;
    Quaternion originalRotationValue;
  
    // Start is called before the first frame update
    void Start()
    {
        originalRotationValue = transform.rotation;
        allChildren = new List<GameObject>();
        string destination = Application.dataPath + "/StreamingAssets/Input";
        destination = destination.Replace("/", @"\");
        var ext = new List<string> { "obj","dae" };
        var myFiles = Directory
            .EnumerateFiles(destination, "*.*", SearchOption.AllDirectories)
            .Where(s => ext.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()));

        foreach(string model in myFiles )
        {
          
            var ob = MeshImporter.Load(model);
            ob.transform.SetParent(this.transform, false);

            allChildren.Add(ob);

        }
     
        if (allChildren.Count>0)
        {
            foreach (GameObject child in allChildren)
            {
                child.SetActive(false);
            }
            
            allChildren[0].SetActive(true);
        }
     
      



    }
    public void NextChild()
    {
        transform.rotation = originalRotationValue;
        allChildren[currentChild].SetActive(false);
        if (currentChild + 1 > allChildren.Count - 1)
            currentChild = 0;
        else
        {
            ++currentChild;
        }
          

        allChildren[currentChild].SetActive(true);
    }
    public void PreviousChild()
    {
        transform.rotation = originalRotationValue;
        allChildren[currentChild].SetActive(false);
        if (currentChild - 1 <0)
            currentChild = allChildren.Count - 1;
        else
            --currentChild;

        allChildren[currentChild].SetActive(true);
    }

}
