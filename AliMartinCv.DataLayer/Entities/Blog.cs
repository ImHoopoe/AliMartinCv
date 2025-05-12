using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AliMartinCv.DataLayer.Entities
{
    public class Blog
    {
        [Key]
        public Guid BlogId { get; set; }

        [Display(Name = "Blog Title")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(150)]
        public string BlogTitle { get; set; }

        [Display(Name = "Blog Short Description")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(150)]
        public string BlogShortDescription { get; set; }

        [Display(Name = "Blog Description")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        public string BlogDescription { get; set; }

        [Display(Name = "Blog Tags")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(150)]
        public string? Tags { get; set; }

        [Display(Name = "Blog Thumbnail")]
        [MaxLength(150)]
        public string? BlogThumbnail { get; set; }

        [Display(Name = "Blog Publish Date")]
        public DateTime BlogPublishDate { get; set; }

        [Display(Name = "Visit Count")]
        public int? Visit { get; set; }

        [Display(Name = "Is Deleted")]
        public bool BlogIsDeleted { get; set; }

        public Guid BlogGroupId { get; set; }
        public Guid? BlogSubGroupId { get; set; }

        #region Relations
        [ForeignKey("BlogGroupId")]
        [InverseProperty("Blogs")]
        public BlogGroup? BlogGroup { get; set; }

        [ForeignKey("BlogSubGroupId")]
        [InverseProperty("SubGroupBlogs")]
        public BlogGroup? SubGroup { get; set; }
        #endregion
    }
}
