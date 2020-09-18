using System;
using System.Text;
using UnityEngine;
namespace SQFramework
{ 

    public static class BytesHelper
    {
        #region Byte���
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="src">Ҫ����������</param>
        /// <param name="srcOffset">Ҫ�������ݵĵڼ�λ��ʼ</param>
        /// <param name="dst">Ҫ�洢������</param>
        /// <param name="dstOffset">Ҫ�洢���ݵĵڼ�λ��ʼ</param>
        /// <param name="count">����ٳ���</param>
        public static void CopyArray(Array src, int srcOffset, Array dst, int dstOffset, int count)
        {
            Buffer.BlockCopy(src, srcOffset, dst, dstOffset, count);
        }
        //public static void CopyArray(Array src, int srcOffset, Array dst, int dstOffset, int count)
        //{
        //    Array.Copy(src, srcOffset, dst, dstOffset, count);
        //}

        /// <summary>
        /// byte[] ת��str
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string PressStr(byte[] buffer)
        {
            return Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        }
        /// <summary>
        /// strת��Byte[]
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] PressByte(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
        /// <summary>
        /// Texture��ת��
        /// </summary>
        /// <param name="texture"></param>
        /// <returns></returns>
        public static Texture2D TextureToTexture2D(Texture texture)
        {//Textureת��Texture2d
            Texture2D texture2D = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
            RenderTexture currentRT = RenderTexture.active;
            RenderTexture renderTexture = RenderTexture.GetTemporary(texture.width, texture.height, 32);
            Graphics.Blit(texture, renderTexture);
            RenderTexture.active = renderTexture;
            texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture2D.Apply();//������Ϣ������2D������ͼ��;
            RenderTexture.active = currentRT;
            RenderTexture.ReleaseTemporary(renderTexture);
            return texture2D;
        }


        #endregion

    }
}