using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CubeTests
{
    [UnityTest]
    public IEnumerator CubePositionTest()
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(1, 0, 0);
        yield return new WaitForSeconds(1);
        Assert.AreEqual(cube.transform.position, new Vector3(1, 0, 0));
    }
}
