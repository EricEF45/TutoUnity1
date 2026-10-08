using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class CallCPP : MonoBehaviour
{
    public int countPerformance = 1000000;

    void Start()
    {
        print($"ce code vient de cpp : {isThisCpp()}");
        print($"2^2 : {squareNumber(2)}");
        print($"2^2^2 : {cubeNumber(2)}");
        GetSumNumbersFromCPP(10, 20);
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Stopwatch w = Stopwatch.StartNew();
            int calls = 0;
            for (int i = 0; i < countPerformance; i++)
            {
                var r = cubeNumber(125);
                calls++;
            }
            w.Stop();
            print($"CPP performance for {calls}: {w.ElapsedMilliseconds}");
            w = Stopwatch.StartNew();
            calls = 0;
            for (int i = 0; i < countPerformance; i++)
            {
                var r = cubeNumberCsharp(125);
                calls++;
            }
            w.Stop();
            print($"C# performance for {calls}: {w.ElapsedMilliseconds}");
        }
    }


    [DllImport("PluginCpp.dll")]
    public static extern bool isThisCpp();
    [DllImport("PluginCpp.dll")]
    public static extern int sumNumbers(int a, int b);
    [DllImport("PluginCpp.dll")]
    public static extern int squareNumber(int a);
    [DllImport("PluginCpp.dll")]
    public static extern int cubeNumber(int a);

    private int cubeNumberCsharp(int a) {
        return a * a * a;
    }

    public void GetSumNumbersFromCPP(int a, int b)
    {
        print($"{a} + {b} = {sumNumbers(a, b)}");
    }
    public void GetSquareFromCPP(int a)
    {
        print($"Square {a} = {squareNumber(a)}");
    }
}
