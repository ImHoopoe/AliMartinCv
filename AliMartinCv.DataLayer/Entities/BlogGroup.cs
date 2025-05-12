using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AliMartinCv.DataLayer.Entities
{
    public class BlogGroup
    {
        [Key]
        public Guid BlogGroupId { get; set; }

        [Display(Name = "Group Title")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(150)]
        public string BlogGroupTitle { get; set; }

        [Display(Name = "Group's Parent")]
        public Guid? BlogGroupParentId { get; set; }

        [Display(Name = "Is Deleted ?")]
        public bool IsDeleted { get; set; }

        #region Relations 
        [ForeignKey("BlogGroupParentId")]
        public List<BlogGroup> SubGroups { get; set; }

        [InverseProperty("BlogGroup")]
        public List<Blog> Blogs { get; set; }

        [InverseProperty("SubGroup")]
        public List<Blog> SubGroupBlogs { get; set; }
        #endregion
    }
}
