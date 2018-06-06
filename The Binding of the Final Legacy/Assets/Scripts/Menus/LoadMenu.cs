using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class LoadMenu : MonoBehaviour
{
    private DirectoryInfo info;
    public FileInfo[] files;
    public List<string> fileNames;
    //private List<GameObject> saveListUI;
    // Use this for initialization
    void Start ()
    {
        fileNames = new List<string>();
        //saveListUI = new List<GameObject>();

        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    if (transform.GetChild(i).CompareTag("LoadMenuSave"))
        //    {
        //        saveListUI.Add(transform.GetChild(i).gameObject);
        //    }
        //}

        info = new DirectoryInfo("C:/Savegames/");
        files = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();

        foreach (FileInfo file in files)
        {
            fileNames.Add(file.Name.Substring(0, file.Name.Length - 4));
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
