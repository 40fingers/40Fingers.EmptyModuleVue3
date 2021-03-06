using DotNetNuke.ComponentModel.DataAnnotations;

namespace FortyFingers.EmptyModuleVue3.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [TableName("EmptyModuleVue3_Items")]
    //setup the primary key for table
    [PrimaryKey("Id", AutoIncrement = true)]
    [Scope("ModuleId")]
    public partial class Item
    {
        [Key]
        public int Id { get; set; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public int? AssignedUserId { get; set; }

        public int ModuleId { get; set; }

        public DateTime CreatedOnDate { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime LastModifiedOnDate { get; set; }

        public int LastModifiedByUserId { get; set; }

    }
}
