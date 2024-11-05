using CCommandShell.Filesystem;
using Newtonsoft.Json;




namespace CCommandShell.Persistency
{
    public class PersistencyService
    {
        public static string Filename = "Filesystem.json";
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
                Filesystem.Directory rootDir = new Filesystem.Directory("", DateTime.Now, new List<FilesystemItem>());

                return new Drive(rootDir, "Windows", "C", "CShell", winDrive.DriveType.ToString());
            }
        }
        public static void Save(Drive driver)
        {
            string json = JsonConvert.SerializeObject(driver, settings);
            System.IO.File.WriteAllText(Filename, json);
        }
    }
}
