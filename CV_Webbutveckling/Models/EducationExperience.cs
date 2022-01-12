using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV_Webbutveckling.Models
{
    public class EducationExperience
    {
        [Required]
        public int Id { get; set; }
        [DataType(DataType.Date)]

        public DateTime DateStart { get; set; }
        [DataType(DataType.Date)]

        public DateTime DateEnd { get; set; }
        [Column(TypeName = "Nvarchar(255)")]
        public string SchoolName { get; set; }
        [Column(TypeName = "Nvarchar(255)")]
        public string EducationName { get; set; }
        [Required]
        public string Description { get; set; }
    }

 
 
}
