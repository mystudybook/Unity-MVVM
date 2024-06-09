using System;
using UnityEngine;

public class ModelService
{

    public Model GetData()
    {
        Model m = new Model()
        {
            Name = PlayerPrefs.GetString("name"),
            Job = PlayerPrefs.GetString("job"),
        };

        return m;
    }

    public void SaveNmae(string name)
    {
        PlayerPrefs.SetString("name", name);
    }

    public void SaveJob(string job)
    {
        PlayerPrefs.SetString("job", job);
    }
}
