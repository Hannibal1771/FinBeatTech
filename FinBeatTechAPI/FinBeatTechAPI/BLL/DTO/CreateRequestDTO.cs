using System.ComponentModel.DataAnnotations;

namespace FinBeatTechAPI.BLL.DTO
{
    public class CreateRequestDTO
    {
        [Required]
        public int Code { get; set; }

        [MaxLength(100)]
        public string Value { get; set; }
    }
}
