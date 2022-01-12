using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV_Webbutveckling.Models
{
    public class WorkExperience
    {
        [Required]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
        [Column(TypeName = "Nvarchar(255)"),Required]
        public string CompanyName { get; set; }
        [Column(TypeName = "Nvarchar(255)")]
        public string PositionName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
