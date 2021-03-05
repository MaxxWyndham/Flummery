using System;
using System.Drawing;
using Flummery.Core;

using OpenTK;
using OpenTK.Graphics.OpenGL;

using ToxicRagers.Helpers;

namespace Flummery.Renderer
{
    class OpenTKRenderer : IRenderer
    {
        public void MatrixMode(string matrixMode)
        {
            GL.MatrixMode(matrixMode.ToEnum<MatrixMode>());
        }

        public void LoadMatrix(ref Matrix4D matrix)
        {
            Matrix4 m = matrix.ToMatrix4();

            GL.LoadMatrix(ref m);

            matrix.M11 = m.M11; matrix.M12 = m.M12; matrix.M13 = m.M13; matrix.M14 = m.M14;
            matrix.M21 = m.M21; matrix.M22 = m.M22; matrix.M23 = m.M23; matrix.M24 = m.M24;
            matrix.M31 = m.M31; matrix.M32 = m.M32; matrix.M33 = m.M33; matrix.M34 = m.M34;
            matrix.M41 = m.M41; matrix.M42 = m.M42; matrix.M43 = m.M43; matrix.M44 = m.M44;
        }

        public void MultMatrix(ref Matrix4D matrix)
        {
            Matrix4 m = matrix.ToMatrix4();

            GL.MultMatrix(ref m);

            matrix.M11 = m.M11; matrix.M12 = m.M12; matrix.M13 = m.M13; matrix.M14 = m.M14;
            matrix.M21 = m.M21; matrix.M22 = m.M22; matrix.M23 = m.M23; matrix.M24 = m.M24;
            matrix.M31 = m.M31; matrix.M32 = m.M32; matrix.M33 = m.M33; matrix.M34 = m.M34;
            matrix.M41 = m.M41; matrix.M42 = m.M42; matrix.M43 = m.M43; matrix.M44 = m.M44;
        }

        public void LoadIdentity()
        {
            GL.LoadIdentity();
        }

        public void Ortho(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            GL.Ortho(left, right, bottom, top, zNear, zFar);
        }

        public void Enable(string cap)
        {
            GL.Enable(cap.ToEnum<EnableCap>());
        }

        public void Disable(string cap)
        {
            GL.Disable(cap.ToEnum<EnableCap>());
        }

        public void PolygonMode(string materialFace, string polygonMode)
        {
            GL.PolygonMode(materialFace.ToEnum<MaterialFace>(), polygonMode.ToEnum<PolygonMode>());
        }

        public void Begin(Core.PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType.ToString().ToEnum<OpenTK.Graphics.OpenGL.PrimitiveType>());
        }

        public void End()
        {
            GL.End();
        }

        public void FrontFace(string frontFace)
        {
            GL.FrontFace(frontFace.ToEnum<FrontFaceDirection>());
        }

        public void Color3(Color colour)
        {
            GL.Color3(colour);
        }

        public void Color4(Color colour)
        {
            GL.Color4(colour);
        }

        public void Color4(Colour colour)
        {
            GL.Color4(Color.FromArgb(
                (int)colour.A,
                (int)colour.R,
                (int)colour.G,
                (int)colour.B));
        }

        public void Color4(float r, float g, float b, float a)
        {
            GL.Color4(r, g, b, a);
        }

        public void Vertex2(float x, float y)
        {
            GL.Vertex2(x, y);
        }

        public void Vertex3(float x, float y, float z)
        {
            GL.Vertex3(x, y, z);
        }

        public void Light(string lightName, string lightParameter, float[] f)
        {
            GL.Light(lightName.ToEnum<LightName>(), lightParameter.ToEnum<LightParameter>(), f);
        }

        public void LightModel(string lightModelParameter, float[] f)
        {
            GL.LightModel(lightModelParameter.ToEnum<LightModelParameter>(), f);
        }

        public void LightModel(string lightModelParameter, float f)
        {
            GL.LightModel(lightModelParameter.ToEnum<LightModelParameter>(), f);
        }

        public void ClearColor(Color colour)
        {
            GL.ClearColor(colour);
        }

        public void Viewport(int x, int y, int width, int height)
        {
            GL.Viewport(x, y, width, height);
        }

        public void Scissor(int x, int y, int width, int height)
        {
            GL.Scissor(x, y, width, height);
        }

        public void Clear(params string[] mask)
        {
            ClearBufferMask clearBufferMask = ClearBufferMask.None;

            foreach (string m in mask) { clearBufferMask |= m.ToEnum<ClearBufferMask>(); }

            GL.Clear(clearBufferMask);
        }

        public void LineWidth(float width)
        {
            GL.LineWidth(width);
        }
        public void BindTexture(string textureTarget, int texture)
        {
            GL.BindTexture(textureTarget.ToEnum<TextureTarget>(), texture);
        }

        public void DepthFunc(string depthFunction)
        {
            GL.DepthFunc(depthFunction.ToEnum<DepthFunction>());
        }

        public void TexCoord4(ToxicRagers.Helpers.Vector4 v)
        {
            GL.TexCoord4(v.ToVector4());
        }

        public void Normal3(ToxicRagers.Helpers.Vector3 v)
        {
            GL.Normal3(v.ToVector3());
        }

        public void Vertex3(ToxicRagers.Helpers.Vector3 v)
        {
            GL.Vertex3(v.ToVector3());
        }

        public void PolygonOffset(float factor, float units)
        {
            GL.PolygonOffset(factor, units);
        }

        public void PushMatrix()
        {
            GL.PushMatrix();
        }

        public void PopMatrix()
        {
            GL.PopMatrix();
        }

        public void GenBuffers(int n, out int buffers)
        {
            GL.GenBuffers(n, out buffers);
        }

        public void BindBuffer(string bufferTarget, int buffer)
        {
            GL.BindBuffer(bufferTarget.ToEnum<BufferTarget>(), buffer);
        }

        public void BufferData<T2>(string target, IntPtr size, T2[] data, string usage) where T2 : struct
        {
            GL.BufferData(target.ToEnum<BufferTarget>(), size, data, usage.ToEnum<BufferUsageHint>());
        }

        public void EnableClientState(string arrayCap)
        {
            GL.EnableClientState(arrayCap.ToEnum<ArrayCap>());
        }

        public void DisableClientState(string arrayCap)
        {
            GL.DisableClientState(arrayCap.ToEnum<ArrayCap>());
        }

        public void GenTextures(int n, out int textures)
        {
            GL.GenTextures(n, out textures);
        }

        public void TexParameter(string target, string pname, int param)
        {
            GL.TexParameter(target.ToEnum<TextureTarget>(), pname.ToEnum<TextureParameterName>(), param);
        }

        public void TexImage2D(string target, int level, string internalformat, int width, int height, int border, string format, string type, IntPtr pixels)
        {
            GL.TexImage2D(target.ToEnum<TextureTarget>(), level, internalformat.ToEnum<PixelInternalFormat>(), width, height, border, format.ToEnum<PixelFormat>(), type.ToEnum<PixelType>(), pixels);
        }

        public void CompressedTexImage2D<T7>(string target, int level, string internalformat, int width, int height, int border, int imageSize, T7[] data) where T7 : struct
        {
            GL.CompressedTexImage2D(target.ToEnum<TextureTarget>(), level, internalformat.ToEnum<InternalFormat>(), width, height, border, imageSize, data);
        }

        public void TexSubImage2D(string target, int level, int xoffset, int yoffset, int width, int height, string format, string type, IntPtr pixels)
        {
            GL.TexSubImage2D(target.ToEnum<TextureTarget>(), level, xoffset, yoffset, width, height, format.ToEnum<PixelFormat>(), type.ToEnum<PixelType>(), pixels);
        }

        public void Finish()
        {
            GL.Finish();
        }

        public void DeleteTexture(int textures)
        {
            GL.DeleteTexture(textures);
        }

        public void BlendFunc(string sfactor, string dfactor)
        {
            GL.BlendFunc(sfactor.ToEnum<BlendingFactor>(), dfactor.ToEnum<BlendingFactor>());
        }

        public void TexEnv(string target, string pname, float param)
        {
            GL.TexEnv(target.ToEnum<TextureEnvTarget>(), pname.ToEnum<TextureEnvParameter>(), param);
        }

        public void TexCoord2(float s, float t)
        {
            GL.TexCoord2(s, t);
        }

        public void VertexPointer(int size, string type, int stride, IntPtr pointer)
        {
            GL.VertexPointer(size, type.ToEnum<VertexPointerType>(), stride, pointer);
        }

        public void NormalPointer(string type, int stride, IntPtr pointer)
        {
            GL.NormalPointer(type.ToEnum<NormalPointerType>(), stride, pointer);
        }

        public void TexCoordPointer(int size, string type, int stride, IntPtr pointer)
        {
            GL.TexCoordPointer(size, type.ToEnum<TexCoordPointerType>(), stride, pointer);
        }

        public void ColorPointer(int size, string type, int stride, IntPtr pointer)
        {
            GL.ColorPointer(size, type.ToEnum<ColorPointerType>(), stride, pointer);
        }

        public void DrawElements(Core.PrimitiveType mode, int count, string type, IntPtr indices)
        {
            GL.DrawElements(mode.ToString().ToEnum<OpenTK.Graphics.OpenGL.PrimitiveType>(), count, type.ToEnum<DrawElementsType>(), indices);
        }

        public void Hint(string target, string mode) {
            GL.Hint(target.ToEnum<HintTarget>(), mode.ToEnum<HintMode>());
        }

        public void ShadeModel(string model) {
            GL.ShadeModel(model.ToEnum<ShadingModel>());
        }

        public void PointSize(float size)
        {
            GL.PointSize(size);
        }

        public void GetFloat(string pname, out Matrix4D matrix)
        {
            matrix = Matrix4D.Identity;

            GL.GetFloat(pname.ToEnum<GetPName>(), out Matrix4 m);

            matrix.M11 = m.M11; matrix.M12 = m.M12; matrix.M13 = m.M13; matrix.M14 = m.M14;
            matrix.M21 = m.M21; matrix.M22 = m.M22; matrix.M23 = m.M23; matrix.M24 = m.M24;
            matrix.M31 = m.M31; matrix.M32 = m.M32; matrix.M33 = m.M33; matrix.M34 = m.M34;
            matrix.M41 = m.M41; matrix.M42 = m.M42; matrix.M43 = m.M43; matrix.M44 = m.M44;
        }

        public void GetInteger(string pname, int[] data)
        {
            GL.GetInteger(pname.ToEnum<GetPName>(), data);
        }
    }

    static class ExtensionMethods
    {
        public static Matrix4 ToMatrix4(this Matrix4D m)
        {
            if (m == null) { return Matrix4.Identity; }

            return new Matrix4(
                m.M11, m.M12, m.M13, m.M14,
                m.M21, m.M22, m.M23, m.M24,
                m.M31, m.M32, m.M33, m.M34,
                m.M41, m.M42, m.M43, m.M44);
        }

        public static OpenTK.Vector3 ToVector3(this ToxicRagers.Helpers.Vector3 v)
        {
            return new OpenTK.Vector3(v.X, v.Y, v.Z);
        }

        public static OpenTK.Vector4 ToVector4(this ToxicRagers.Helpers.Vector4 v)
        {
            return new OpenTK.Vector4(v.X, v.Y, v.Z, v.W);
        }
    }
}
