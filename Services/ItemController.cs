﻿using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Common;
using DotNetNuke.Web.Api;
using DotNetNuke.Security;
using System.Threading;
using DotNetNuke.UI.Modules;
using DotNetNuke.Common.Utilities;
using System.Collections.Generic;
using DotNetNuke.Data;
using FortyFingers.EmptyModuleVue3.Components.BaseClasses;
using FortyFingers.EmptyModuleVue3.Data;
using FortyFingers.EmptyModuleVue3.Services.ViewModels;
using Newtonsoft.Json.Linq;

namespace FortyFingers.EmptyModuleVue3.Services
{
    //[SupportedModules("40F EmptyModuleVue3")]
    //[DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.Anonymous)]
    [AllowAnonymous]
    public class ItemController : ApiControllerBase
    {
        public ItemController() { }

        public HttpResponseMessage Delete(int itemId)
        {
            // TODO: Implement

            return Request.CreateResponse(System.Net.HttpStatusCode.NoContent);
        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("GetItem")]
        public HttpResponseMessage GetItem(int itemId)
        {
            ItemViewModel retval = null;

            if (itemId > 0)
            {
                using (var dctx = DataContext.Instance())
                {
                    var rep = dctx.GetRepository<Item>();
                    var item = rep.GetById(itemId);
                    retval = new ItemViewModel(item);
                }
            }
            else
            {
                retval = new ItemViewModel();
            }
            return Request.CreateResponse(retval ?? new ItemViewModel());
        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("GetList")]
        public HttpResponseMessage GetList()
        {
            var retval = new List<ItemViewModel>();
            var items = new List<Item>();

            using (var dctx = DataContext.Instance())
            {
                var rep = dctx.GetRepository<Item>();
                items = rep.Get().ToList();
            }

            items.ForEach(i => retval.Add(new ItemViewModel(i)));

            return Request.CreateResponse(retval);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AllowAnonymous]
        //[HttpGet]
        [ActionName("Save")]
        public HttpResponseMessage Save(ItemViewModel item)
        {
            using (var dctx = DataContext.Instance())
            {
                var rep = dctx.GetRepository<Item>();
                var saveItem = item.Id > 0 ? rep.GetById(item.Id) : new Item()
                {
                    ModuleId = this.ActiveModule?.ModuleID ?? 1354,
                    AssignedUserId = UserInfo.UserID,
                    CreatedByUserId = UserInfo.UserID,
                    CreatedOnDate = DateTime.Now
                };
                saveItem.ItemName = item.Name;
                saveItem.ItemDescription = item.Description;
                saveItem.LastModifiedByUserId = UserInfo.UserID;
                saveItem.LastModifiedOnDate = DateTime.Now;

                if (saveItem.Id > 0)
                {
                    rep.Update(saveItem);
                }
                else
                {
                    rep.Insert(saveItem);
                }
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, new { });
        }

        private Item Create(ItemViewModel item)
        {
            Item t = new Item
            {
                ItemName = item.Name,
                ItemDescription = item.Description,
                AssignedUserId = item.AssignedUser,
                ModuleId = ActiveModule.ModuleID,
                CreatedByUserId = UserInfo.UserID,
                LastModifiedByUserId = UserInfo.UserID,
                CreatedOnDate = DateTime.UtcNow,
                LastModifiedOnDate = DateTime.UtcNow
            };
            // TODO: Implement Save

            return t;
        }

        private Item Update(ItemViewModel item)
        {
            Item retval = null;

            // TODO: Implement

            return retval;
        }
    }
}