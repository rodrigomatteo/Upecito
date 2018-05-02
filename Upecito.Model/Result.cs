using System.Collections.Generic;
using System.Linq;

namespace Upecito.Model
{
    public class Result
    {
        public Result()
        {
            Speech = "Oooops!";
            Intents = new List<Intent>();
        }

        public string SessionId { get; set; }
        public string Speech { get; set; }
        public int Status { get; set; }
        public List<Intent> Intents { get; set; }

        public bool ExistIntent => Intents.Count >= 1;

        public bool ExistValidIntent
        {
            get { return ExistIntent & Intents.Any(i => i.Score > 0.08); }
        }

        public string GetValidIntent()
        {
            var intent = Intents.AsEnumerable().FirstOrDefault(i => i.Score > 0.08);
            return intent != null ? intent.IntentName : string.Empty;
        }
    }

    public class Intent
    {
        public string IntentId { get; set; }
        public string IntentName { get; set; }
        public float Score { get; set; }
    }
}