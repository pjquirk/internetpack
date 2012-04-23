using System;
using System.IO;
using System.Security.Cryptography;

namespace RemObjects.InternetPack.Ftp.VirtualFtp
{

  public class SecureStorage
  {
    public SecureStorage(string aBaseFolder)
    {
      fBaseFolder = aBaseFolder;
      fCrypter = new RijndaelManaged();
    }

    ~SecureStorage()
    {
      FreeStorage();
    }

    #region Properties
    private string fStorageFolder;

    private string fBaseFolder;

    RijndaelManaged fCrypter;

    public void ClearStorage()
    {
      FreeStorage();

    {
      if (Directory.Exists(fBaseFolder))
      {
        Directory.Delete(fBaseFolder,true);
    }


    public string GetNewFilename()
    {
      lock (this)
      {
        return Path.Combine(fStorageFolder,Guid.NewGuid().ToString("D"))+".data";
    }

    private Stream WrapReadStream(Stream aStream)
    {
      return new CryptoStream(aStream, fCrypter.CreateDecryptor(), CryptoStreamMode.Read);
    }

    private Stream WrapWriteStream(Stream aStream)
    {
      return new CryptoStream(aStream, fCrypter.CreateEncryptor(), CryptoStreamMode.Write);
    }

    public Stream CreateFile(string aFilename)
    {
      Stream lStream = new FileStream(aFilename,FileMode.Create,FileAccess.Write, FileShare.None);
      return WrapWriteStream(lStream);
    }

    public Stream GetFile(string aFilename, int aOffset)
    {
      Stream lStream = new FileStream(aFilename,FileMode.Open,FileAccess.ReadWrite, FileShare.Read);
      return WrapReadStream(lStream);
    }

  }

}