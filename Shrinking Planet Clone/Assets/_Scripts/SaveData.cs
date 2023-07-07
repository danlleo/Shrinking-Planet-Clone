using UnityEngine;

public class SaveData : MonoBehaviour
{
    public string Name;
    public int Age;

    public SaveData(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
