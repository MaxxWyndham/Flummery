using System;
using ToxicRagers.Helpers;

namespace Flummery
{
    class Node
    {
        bool bRender = true;
        String Name;
        VertexBuffer VBO;
        int TextureID;

        public bool CanRender { get { return bRender; } set { bRender = value; } }

        public Node(string name, VertexBuffer vbo, int textureID = 0)
        {
            Name = name;
            VBO = vbo;
            TextureID = textureID;
        }

        public void Render()
        {
            if (bRender) { VBO.Render(TextureID); }
        }
    }
}
