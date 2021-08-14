using System.ComponentModel.DataAnnotations;

namespace CyService.API.Models.Requests
{
    public class WordLengthCountRequest
    {
        [Required]
        public string InputString { get; set; }
    }
}