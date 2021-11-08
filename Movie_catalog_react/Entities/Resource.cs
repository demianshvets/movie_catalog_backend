using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_catalog_react.Entities
{
    public class Resource
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResourceId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string DataPath { get; set; }

        [Required]
        public ResourceFormat Format { get; set; }
    }
    public enum ResourceFormat
    {
        PNG,
        png,
        jpg,
        JPG,
        JPEG,
        jpeg,
        GIF,
        gif,
        BMP,
        bmp,
        TIFF,
        tiff
    }
}

