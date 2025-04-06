using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinBeatTechAPI.DAL.Entities
{
    [Table("DefaultTable", Schema = "dbo")]
    public class Default
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("code")]
        public int Code { get; set; }

        [Column("value")]
        public string Value { get; set; }
    }
}
