namespace FortyFingers.EmptyModuleVue3.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public string ItemDescription { get; set; }

        public int? AssignedUserId { get; set; }

        public int ModuleId { get; set; }

        public DateTime CreatedOnDate { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime LastModifiedOnDate { get; set; }

        public int LastModifiedByUserId { get; set; }

    }
}
