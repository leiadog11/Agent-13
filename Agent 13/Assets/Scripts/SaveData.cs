using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public GameObject restartButton;
    public void DataSaving()
    {
        string destination = Application.persistentDataPath + "/"
            + System.DateTime.UtcNow.ToLocalTime().ToString("M-d-yy-HH-mm") + ".txt";

        StreamWriter writer = new StreamWriter(destination, true);

        writer.Write("Amount of fails: ");


        writer.Close();
    }
}
