using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using OpenTK.Graphics;

namespace carmaModelViewer
{
    class CustomGLControl : GLControl
    {
        // 32bpp color, 24bpp z-depth, 8bpp stencil and 4x antialiasing
        // OpenGL version is major=3, minor=0
        public CustomGLControl()
            : base(GraphicsMode.Default, 3, 0, GraphicsContextFlags.Default)
        { }
    }
}
