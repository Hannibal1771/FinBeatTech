namespace FinBeatTechAPI.BLL.DTO
{
    public class GetResponseDTO
    {
        public IEnumerable<DefaultDTO> defaultList { get; set; }

        public int TotalRows { get; set; }
    }
}
