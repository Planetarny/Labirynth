using JetBrains.Annotations;
using UnityEngine;

public class WorldGen : MonoBehaviour
{

    public Texture2D pixelmap;
    public ColorToPref[] colorMap;
    public float offset = 10f;
    public Material mainmat;
    public Material extramat;

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

                GenerateTile(x, z);

            }

        }
        ColorWalls();

    }
    
    public void ColorWalls()
    {

        foreach (Transform child in transform)
        {

            if (child.tag == "wall")
            {

                if (Random.Range(0,3)==0)
                {

                    child.gameObject.GetComponent<Renderer>().material = extramat;

                }
                else
                {

                    child.gameObject.GetComponent<Renderer>().material = mainmat;

                }

            }

        }

    }
}
