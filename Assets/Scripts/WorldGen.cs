using JetBrains.Annotations;
using UnityEngine;

public class WorldGen : MonoBehaviour
{

    public Texture2D pixelmap;
    public ColorToPref[] colorMap;
    public float offset = 10f;

    void GenerateTile(int x, int z)
    {

        Color pixelcolor = pixelmap.GetPixel(x, z);
        if (pixelcolor.a == 0) return;
        foreach (var c in colorMap)
        {

            if (c.color.Equals(pixelcolor))
            {

                Vector3 pos  = new Vector3(x,0,z)*offset;
                Instantiate(c.prefab,pos,Quaternion.identity,transform);

            }

        }
        
    }
    public void GenerateLabirynth()
    {

        for (int x = 0; x < pixelmap.width; x++) 
        {

            for (int z = 0; z < pixelmap.height; z++) 
            {

                GenerateTile(x,z);

            }

        }

    }
}
