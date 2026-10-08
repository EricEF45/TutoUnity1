using System.IO;
using System.Security.Cryptography;
using System;
using TMPro;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text pathtext;

    public string CalculateMD5(string file)
    {
        using (var md5 = MD5.Create())
        {
            using (var stream = File.OpenRead(file))
            {
                var hash = md5.ComputeHash(stream);
                return BitConverter.ToString(hash);
            }
        }
    }

    private void Start()
    {
        var s = string.Empty;
#pragma warning disable UAC0007 // Assembly.Location
        string path = Path.Combine(Path.GetFullPath("."), "Tutos.exe");
#pragma warning restore UAC0007 // Assembly.Location
        pathtext.text = path;
        try
        {
            string hash = CalculateMD5(path);
            s += $"hash={hash}";

            if (Application.genuineCheckAvailable)
            {
                s += $" Genuie={Application.genuine}";
            }

            text.text = s;
        }
        catch (Exception e)
        {
            text.color = Color.red;
            text.text = e.Message;
        }
    }
}
