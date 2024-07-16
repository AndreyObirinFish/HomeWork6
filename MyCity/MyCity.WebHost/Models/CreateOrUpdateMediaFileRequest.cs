using System;
using MyCity.Dtos.Enums;

namespace MyCity.WebHost.Models
{
    public class CreateOrUpdateMediaFileRequest
    {
        public required Uri Uri { get; set; }
        public string? Description { get; set; }
        public MediaFileType MediaFileType { get; set; }
    }
}
