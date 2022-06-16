using DotNetNuke.Entities.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FortyFingers.EmptyModuleVue3.Services.ViewModels
{
    [JsonObject(MemberSerialization.OptIn)]
    public class UserViewModel
    {
        public UserViewModel(UserInfo t)
        {
            Id = t.UserID;
            Name = t.DisplayName;
        }

        public UserViewModel() { }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}