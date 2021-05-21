using SportsAppDavidNicholOOP.Models;
using SportsAppDavidNicholOOP.Models.Interfaces;
using SportsAppDavidNicholOOP.Models.Team;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SportsAppDavidNicholOOP
{
    [Serializable]
    public class Repo
    {
        public MatchResult MatchResults { get; set; }

        public string MatchOutput { get; set; }

        public string FilePath { get; set; }

        public Match Match { get; set; }

        public Repo(IMatch match)
        {
            MatchResults = new MatchResult(match);
            FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SportsAppSaveFile.bin");
        }

        public void Save(string typeOfObject)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream iostream = new FileStream(this.FilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                if(typeOfObject == "MatchResult")
                {
                    formatter.Serialize(iostream, MatchResults);
                    formatter.Serialize(iostream, MatchOutput);
                }
                else if(typeOfObject == "Match")
                    formatter.Serialize(iostream, Match);
            }
        }

        public MatchResult LoadMatchResults()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            MatchResult matchResult = (MatchResult)formatter.Deserialize(stream);
            stream.Close();
            return matchResult;
        }

        public Match LoadMatch()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            Match match = (Match)formatter.Deserialize(stream);
            stream.Close();
            return match;
        }

    }
}

