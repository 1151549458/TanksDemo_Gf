using System;
using System.IO;
namespace SQFramework
{
    public static class DirFileHelper
    {
        #region �ļ��в��� 
        /// <summary>
        /// �����κ����͵��ļ�
        /// </summary>
        /// <param name="fileBytes">�ļ���</param>
        /// <param name="path">��ǰ�ļ���·��</param>
        /// <param name="folderName">�ļ���</param>
        /// <param name="fileName">�ļ�������׺</param>
        public static void SavaFile(byte[] fileBytes, string path, string folderName, string fileName)
        {
            FileStream fs = new FileStream(path + "/" + folderName + "/" + fileName, FileMode.Create, FileAccess.Write);
            fs.Write(fileBytes, 0, fileBytes.Length);
            fs.Dispose();
            fs.Close();
        }
        public static void SavaFile(byte[] fileBytes, string path, string fileName)
        {
            FileStream fs = new FileStream(path + "/" + fileName, FileMode.Create, FileAccess.Write);
            fs.Write(fileBytes, 0, fileBytes.Length);
            fs.Dispose();
            fs.Close();
        }
        public static void SavaFile(byte[] fileBytes, string filepath)
        {
            using (FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                fs.Write(fileBytes, 0, fileBytes.Length);
                fs.Dispose();
                fs.Close();
            }
        }
        /// <summary>
        /// ���ļ�
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static byte[] ReadFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                int dataLength = (int)fs.Length; //���ÿ���ļ��Ĵ�С
                byte[] buffer = new byte[dataLength];
                fs.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }
        public static string[] ReadTextLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
        public static string ReadAllText(string filePath)
        {
            return File.ReadAllText(filePath);
        }
     
        /// <summary>
        /// ����һ���ı��ļ�
        /// </summary>
        /// <param name="fileName">�ļ�·��</param>
        /// <param name="content">�ļ�����</param>
        public static void CreateFileTxt(string fileName, string content)
        {
            StreamWriter streamWriter = File.CreateText(fileName);
            streamWriter.Write(content);
            streamWriter.Close();
        }
        /// <summary>
        /// ����һ���ļ���
        /// </summary>
        /// <param name="fileName">���fileName �� path + id </param>
        public static void CreateDirectory(string fileName)
        {
            if (!IsExistsDirectory(fileName))
            {
                Directory.CreateDirectory(fileName);
            }
        }
        /// <summary>
        /// ɾ��һ���ļ���
        /// </summary>
        /// <param name="fileName"></param>
        public static void DeleteDirectory(string fileName)
        {
            if (IsExistsDirectory(fileName))
            {
                Directory.Delete(fileName, true);
            }
        }
        /// <summary>
        /// ��õ�ǰ�ļ����������ļ���
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetAllDirectory(string path)
        {
            return Directory.GetDirectories(path);
        }
        /// <summary>
        /// ��ȡ·�������е��ļ�
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetAllFile(string path)
        {
            return Directory.GetFiles(path);
        }
        /// <summary>
        /// ��ȡ·����ĳ���ļ�
        /// </summary>
        /// <param name="path"></param>
        /// <param name="searchPattern">*jpg</param>
        /// <returns></returns>
        public static string[] GetAllFile(string path, string searchPattern)
        {
            return Directory.GetFiles(path, searchPattern);
        } 
        /// <summary>
        /// �ж��ļ��Ƿ����
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsExistsFile(string fileName)
        {
            return File.Exists(fileName);
        }
        /// <summary>
        /// �ж��ļ����Ƿ����
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsExistsDirectory(string fileName)
        {
            return Directory.Exists(fileName);
        }
        #endregion

    }
}