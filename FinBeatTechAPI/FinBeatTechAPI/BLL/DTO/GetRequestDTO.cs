using System.Reflection.Metadata.Ecma335;

namespace FinBeatTechAPI.BLL.DTO
{
    public class GetRequestDTO
    {
        public int Page { get; set; }

        public int Limit { get; set; }

        public string? filterValue { get; set; }
    }
}
