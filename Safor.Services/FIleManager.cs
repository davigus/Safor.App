using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Safor.Services
{
    public interface IFileManager
    {
        void RenameFile(string fullOldName, string newName);
    }
    public class FIleManager : IFileManager
    {
        public void RenameFile(string fullOldName, string newName)
        { 
            if(!File.Exists(fullOldName))
                throw new FileNotFoundException();

            string fullNewName = Path.GetDirectoryName(fullOldName) + $@"\{newName.Replace(":","_")}.eml";
            File.Move(fullOldName, fullNewName);
        }
    }
}
