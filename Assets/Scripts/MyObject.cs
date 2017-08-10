using UnityEngine;
using System.Collections;

public class MyObject : MonoBehaviour
{
    public static string IdMembre="";
    void Awake()
    {
        Application.ExternalCall("TalkWhithUnity", "This is a mesasage from unity");
    }

    public void MyFunction(string data)
    {
        MyObject.IdMembre = data;
    }
}
