using System.Collections.Generic;
using FortyFingers.EmptyModuleVue3.Components;
using FortyFingers.EmptyModuleVue3.Data;
using Newtonsoft.Json;

namespace FortyFingers.EmptyModuleVue3.Services.ViewModels
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ItemsViewModel
    {
        [JsonProperty("canEdit")]
        public bool CanEdit { get; set; }
        [JsonProperty("items")]
        public List<ItemViewModel> Items { get; set; } = new List<ItemViewModel>();
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ItemViewModel
    {
        public ItemViewModel(Item t)
        {
            Id = t.Id;
            Name = t.ItemName;
            Description = t.ItemDescription;
            AssignedUser = t.AssignedUserId;
        }


        public ItemViewModel() { }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("assignedUser")]
        public int? AssignedUser { get; set; }

    }
}