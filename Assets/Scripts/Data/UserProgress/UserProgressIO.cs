using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class UserProgressIO
{
    private string userProgressPath = Path.Combine(Application.persistentDataPath, "userprogress.data");

    public UserProgressData Read()
    {
        if (File.Exists(userProgressPath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(userProgressPath, FileMode.Open);
            var data = (UserProgressData)bf.Deserialize(file);
            file.Close();
            return data;
        }
        else
        {
            return new UserProgressData();
        }
    }

    public void Write(UserProgressData userProgress)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(userProgressPath);
        bf.Serialize(file, userProgress);
        file.Close();
    }
}
