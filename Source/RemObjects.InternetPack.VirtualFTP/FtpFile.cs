using System;
using System.IO;

namespace RemObjects.InternetPack.Ftp.VirtualFtp
{
  
  public abstract class FtpFile : FtpItem, IFtpFile
	{
    protected FtpFile(IFtpFolder aParent, string aName) : base(aParent, aName)
		{
		}
    
    public abstract void GetFile(Stream aToStream);
    private bool fComplete;

    public override void FillFtpListingItem(FtpListingItem aItem)
    {
      base.FillFtpListingItem(aItem);
      aItem.Directory = false;
      aItem.Size = Size;
      aItem.UserRead = Complete && UserRead;
      aItem.UserWrite = Complete && UserWrite;
      aItem.UserExec = false;
      aItem.GroupRead = Complete && GroupRead;
      aItem.GroupWrite = Complete && GroupWrite;
      aItem.GroupExec = false;
      aItem.OtherRead = Complete && WorldRead;
      aItem.OtherWrite = Complete && WorldWrite;
      aItem.OtherExec = false;
    }


    public virtual bool AllowGet(VirtualFtpSession aSession)
    }
    }
    }
    }

}