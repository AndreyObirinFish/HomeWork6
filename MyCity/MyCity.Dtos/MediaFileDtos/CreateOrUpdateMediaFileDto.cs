using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyCity.Dtos.Enums;

namespace MyCity.Dtos.MediaFileDtos
{
    public class CreateOrUpdateMediaFileDto
    {
        public required Uri Uri { get; set; }
    
        [MaxLength(100)]
        public string? Description { get; set; }
    
        public MediaFileType MediaFileType { get; set; }
    }
}
