using SimpleSettingsManager;
using System;
using System.IO;

namespace ResourcePackUtils
{
    public class Settings
    {
        private readonly SSM _ssm;

        private static readonly string _dirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mullak99", "ResourcePackUtils");
        private static readonly string _path = Path.Combine(_dirPath, "ResourePackUtils.xml");

        public Settings()
        {
            if (!Directory.Exists(_dirPath))
                Directory.CreateDirectory(_dirPath);

            _ssm = new SSM(new SSM_File(_path, SSM_File.Mode.XML));

            _ssm.Open();
            _ssm.AddString("lastMcVersion", "", "Last entered Minecraft version", "Global");
            _ssm.AddBoolean("useMultiMC", false, "If MultiMC jars should be used", "Global");
            _ssm.AddString("multiMcPath", "", "Path to MultiMC exe", "Global");

            _ssm.AddBoolean("includeRealmsMT", true, "Include realms textures when searching for missing textures", "MissingTextures");

            _ssm.AddBoolean("includeRealmsUT", true, "Include realms textures when searching for unused textures", "UnusedTextures");
        }

        public void SetLastEnteredVersion(string version)
        {
            _ssm.SetString("lastMcVersion", version);
        }

        public string GetLastEnteredVersion()
        {
            return _ssm.GetString("lastMcVersion");
        }

        public void SetUseMultiMC(bool useMultiMC)
        {
            _ssm.SetBoolean("useMultiMC", useMultiMC);
        }

        public bool GetUseMultiMC()
        {
            return _ssm.GetBoolean("useMultiMC");
        }

        public void SetMultiMCPath(string path)
        {
            _ssm.SetString("multiMcPath", path);
        }

        public string GetMultiMCPath()
        {
            return _ssm.GetString("multiMcPath");
        }

        public void SetIncludeRealmsMT(bool includeRealms)
        {
            _ssm.SetBoolean("includeRealmsMT", includeRealms);
        }

        public bool GetIncludeRealmsMT()
        {
            return _ssm.GetBoolean("includeRealmsMT");
        }

        public void SetIncludeRealmsUT(bool includeRealms)
        {
            _ssm.SetBoolean("includeRealmsUT", includeRealms);
        }

        public bool GetIncludeRealmsUT()
        {
            return _ssm.GetBoolean("includeRealmsUT");
        }
    }
}
