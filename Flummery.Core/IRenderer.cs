using System;
using System.Drawing;

using ToxicRagers.Helpers;

namespace Flummery.Core
{
    public interface IRenderer
    {
        void MatrixMode(string matrixMode);

        void LoadMatrix(ref Matrix4D matrix);

        void MultMatrix(ref Matrix4D matrix);

        void LoadIdentity();

        void Ortho(float left, float right, float bottom, float top, float zNear, float zFar);

        void PolygonMode(string materialFace, string polygonMode);

        void Enable(string cap);

        void Disable(string cap);

        void FrontFace(string frontFace);

        void Begin(PrimitiveType primitiveType);

        void End();

        void Light(string lightName, string lightParameter, float[] f);

        void LightModel(string lightModelParameter, float[] f);

        void LightModel(string lightModelParameter, float f);

        void Color3(Color colour);

        void Color4(Color colour);

        void Color4(Colour colour);

        void Color4(float r, float g, float b, float a);

        void LineWidth(float width);

        void Vertex2(float x, float y);

        void Vertex3(float x, float y, float z);

        void ClearColor(Color colour);

        void Viewport(int x, int y, int width, int height);

        void Scissor(int x, int y, int width, int height);

        void Clear(params string[] mask);

        void BindTexture(string textureTarget, int texture);

        void DepthFunc(string depthFunction);

        void TexCoord4(Vector4 v);

        void Normal3(Vector3 v);

        void Vertex3(Vector3 v);

        void PolygonOffset(float factor, float units);

        void PushMatrix();

        void PopMatrix();

        void GenBuffers(int n, out int buffers);

        void BindBuffer(string bufferTarget, int buffer);

        void BufferData<T2>(string target, IntPtr size, T2[] data, string usage) where T2 : struct;

        void EnableClientState(string arrayCap);

        void DisableClientState(string arrayCap);

        void GenTextures(int n, out int textures);

        void TexParameter(string target, string pname, int param);

        void TexImage2D(string target, int level, string internalformat, int width, int height, int border, string format, string type, IntPtr pixels);

        void CompressedTexImage2D<T7>(string target, int level, string internalformat, int width, int height, int border, int imageSize, T7[] data) where T7 : struct;

        void Finish();

        void DeleteTexture(int textures);

        void TexSubImage2D(string target, int level, int xoffset, int yoffset, int width, int height, string format, string type, IntPtr pixels);

        void BlendFunc(string sfactor, string dfactor);

        void TexEnv(string target, string pname, float param);

        void TexCoord2(float s, float t);

        void VertexPointer(int size, string type, int stride, IntPtr pointer);

        void NormalPointer(string type, int stride, IntPtr pointer);

        void TexCoordPointer(int size, string type, int stride, IntPtr pointer);

        void ColorPointer(int size, string type, int stride, IntPtr pointer);

        void DrawElements(PrimitiveType mode, int count, string type, IntPtr indices);

        void Hint(string target, string mode);

        void ShadeModel(string model);

        void PointSize(float size);

        void GetFloat(string pname, out Matrix4D matrix);

        void GetInteger(string pname, int[] data);
    }
}
