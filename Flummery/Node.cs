using System;
using ToxicRagers.Helpers;

namespace Flummery
{
    class Node
    {
        String Name;
        VertexBuffer VBO;
        int TextureID;

        public Node(string name, VertexBuffer vbo, int textureID = 0)
        {
            Name = name;
            VBO = vbo;
            TextureID = textureID;
        }

        public void Render()
        {
            VBO.Render(TextureID);
        }
    }
}
