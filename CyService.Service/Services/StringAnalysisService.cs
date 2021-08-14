using System.Collections.Generic;
using System.Linq;
using CyService.Service.Interfaces;

namespace CyService.Service.Services
{
    public class StringAnalysisService : IStringAnalysisService
    {
        public Dictionary<string, int> GetWordLengthCount(string sentence)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            if (!string.IsNullOrWhiteSpace(sentence))
            {
                string[] words = sentence.Split(' ');

                var query =
                    from w in words
                    group w by w.Length into grp
                    orderby grp.Key
                    select new
                    {
                        Length = grp.Key.ToString(),
                        Count = grp.Count()
                    };

                foreach (var obj in query)
                {
                    result.Add(obj.Length, obj.Count);
                }
            }

            return result;
        }
    }
}
