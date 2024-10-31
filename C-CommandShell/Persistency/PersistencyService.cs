using CCommandShell.Filesystem;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CCommandShell.Persistency
{
    internal class PersistencyService
    {
        public const string Filename = "Filesystem.json";
        public static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.All,
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        };

        public PersistencyService() { }


        public static Drive Load()
        {
            if (System.IO.File.Exists(Filename))
            {
                string json = System.IO.File.ReadAllText(Filename);
                return JsonConvert.DeserializeObject<Drive>(json, settings);
            }
            else
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                DriveInfo winDrive = drives[0];
                Filesystem.Directory rootDir = new Filesystem.Directory(new List<FilesystemItem>(), "", DateTime.Now);

                return new Drive(rootDir, "Windows", "C", "users", winDrive.DriveType.ToString());
            }

            return null;
        }
        public static void Save(Drive driver)
        {
            string json = JsonConvert.SerializeObject(driver, settings);
            System.IO.File.WriteAllText(Filename, json);
        }
    }
}
