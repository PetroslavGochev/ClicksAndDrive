namespace ClicksAndDrive.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Image
    {

        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
