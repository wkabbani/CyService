using System.Collections.Generic;

namespace CyService.Service.Interfaces
{
    public interface IStringAnalysisService
    {
        Dictionary<string, int> GetWordLengthCount(string sentence);
    }
}