using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace gfchatbot
{
    public static class GameData
    {
        public static SaveData CurrentSave;

        // Folder path for saves
        private static string SaveFolder
        {
            get
            {
                string folder = Path.Combine(Application.StartupPath, "Saves");
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                return folder;
            }
        }

        // Get full path of a save file
        public static string GetSavePath(string playerName)
        {
            return Path.Combine(SaveFolder, $"{playerName}_save.xml");
        }

        // Check if save file exists
        public static bool SaveExists(string playerName)
        {
            string path = GetSavePath(playerName);
            return File.Exists(path);
        }

        // Save current save data to XML
        public static void SaveGame()
        {
            if (CurrentSave == null || string.IsNullOrEmpty(CurrentSave.PlayerName))
                return;

            string path = GetSavePath(CurrentSave.PlayerName);

            XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, CurrentSave);
            }
        }

        // Load save data from XML
        public static void LoadGame(string playerName)
        {
            string path = GetSavePath(playerName);

            if (!File.Exists(path))
                throw new FileNotFoundException($"Save file not found for player '{playerName}'", path);

            XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                CurrentSave = (SaveData)serializer.Deserialize(fs);
            }
        }

        // Delete save file
        public static void DeleteSave(string playerName)
        {
            string path = GetSavePath(playerName);

            if (File.Exists(path))
                File.Delete(path);

            if (CurrentSave != null && CurrentSave.PlayerName == playerName)
                CurrentSave = null;
        }

        // Create new save data and save it
        public static void StartNewGame(string playerName)
        {
            CurrentSave = new SaveData()
            {
                PlayerName = playerName,
                AngerLevel = 4,
                RelationshipPoints = 0,
                ForgivenessCooldown = 0,
                ChatHistory = new List<string>(),
                ScenarioIndex = new Random().Next(0, 3)
            };

            SaveGame();
        }
    }

    [Serializable]
    public class SaveData
    {
        public string PlayerName { get; set; }
        public int AngerLevel { get; set; }
        public int RelationshipPoints { get; set; }
        public int ForgivenessCooldown { get; set; }
        public int ScenarioIndex { get; set; }
        public List<string> ChatHistory { get; set; } = new List<string>();
    }
}

