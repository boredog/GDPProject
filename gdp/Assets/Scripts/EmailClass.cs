using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailClass : MonoBehaviour
{
    public bool Allowed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Allow()
    {
        Allowed = true;
    }

    public void Reject()
    {
        Allowed = false;
    }

    public bool IsVirus
    {
        get { return (Random.value > 0.5f);  }
    }
}
