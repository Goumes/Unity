using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour
{
    public FileInfo[] files;
    public List<string> fileNames;
    private DirectoryInfo info;

    // Use this for initialization
    void Start ()
    {
        fileNames = new List<string>();

        if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/The Binding of the Final Legacy/"))
        {
            info = new DirectoryInfo(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/The Binding of the Final Legacy/");
            files = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();

            foreach (FileInfo file in files)
            {
                fileNames.Add(file.Name.Substring(0, file.Name.Length - 4));
            }
        }
        else
        {
            files = new FileInfo[0];
        }

        
    }

    private void OnEnable()
    {
        Invoke("firstSelected", 0.01f);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    /// <summary>
    /// Method that selects the first button
    /// </summary>
    private void firstSelected()
    {
        bool found = false;
        for (int i = 0; i < transform.childCount && !found; i++)
        {
            if (transform.GetChild(i).CompareTag("LoadMenuSave"))
            {
                for (int j = 0; j < transform.GetChild(i).transform.childCount; j++)
                {
                    if (transform.GetChild(i).transform.GetChild(j).CompareTag("LoadMenuButton"))
                    {
                        transform.GetChild(i).transform.GetChild(j).transform.GetComponent<Button>().Select();
                        found = true;
                    }
                }
            }
        }
    }
}
