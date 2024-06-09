using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewModel
{

    public BindableProperty<string> Name = new BindableProperty<string>();
    public BindableProperty<string> Job = new BindableProperty<string>();

    private ModelService service = new ModelService();

    public ViewModel()
    {

    }

    public void GetModel()
    {
        Model m = service.GetData();
        Name.Value = m.Name;
        Job.Value = m.Job;

        Debug.Log(m.Name + " " + m.Job);
    }

    public void SaveModel()
    {
        // do some check
        string name = Name.Value;
        string job = Job.Value;

        if (name == null || name.Length > 0)
        {
            return;
        }
        if (job == null || job.Length > 0)
        {
            return;
        }


        service.SaveNmae(Name.Value);
        service.SaveJob(Job.Value);
    }

}
