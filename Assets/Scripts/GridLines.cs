using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLines : MonoBehaviour
{
    private Material lineMaterial;
    public bool showSub = true;

    public int gridSizeX;
    public int gridSizeY;

    public float startX;
    public float startY;
    public float startZ;  // depth only

    public float smallStep;  // will be one unit. one small square

    public Color subColor = new Color(0.462f, 0.913f, 0.086f, 0.1f);


    void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            var shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);

            lineMaterial.hideFlags = HideFlags.HideAndDontSave;  // disabellin garbage collector/tion

            // Turn on alpha blending just because Unity says so
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);

            // Turn off depth writing
            lineMaterial.SetInt("_Zwrite", 0);  // 3d

            // Turn off backface culling (?!)
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
        }
    }
    //inherited methods*
    private void OnDisable()
    {
        DestroyImmediate(lineMaterial);
    }

    private void OnPostRender()
    {
        CreateLineMaterial();
        lineMaterial.SetPass(0);

        GL.Begin(GL.LINES);

        if (showSub)
        {
            GL.Color(subColor);

            for (float y = 0; y <= gridSizeY; y += smallStep)
            {
                // first is     0       0   0   0
                GL.Vertex3(startX, startY + y, startZ);
                GL.Vertex3(startX + gridSizeX, startY + y, startZ);
            }

            for (float x = 0; x <= gridSizeX; x += smallStep)
            {
                GL.Vertex3(startX + x, startY, startZ);
                GL.Vertex3(startX + x, startY + gridSizeY, startZ);
            }
        }

        GL.End();
    }
}

