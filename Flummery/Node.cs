using System;
using ToxicRagers.Helpers;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

namespace carmaModelViewer
{
    class Node
    {
        String Name;
        VertexBuffer VBO;
        Matrix3D world;

        public Node(string name, VertexBuffer vbo)
        {
            Name = name;
            VBO = vbo;
        }

        public void Render()
        {
            VBO.Render();
        }
    }
}
