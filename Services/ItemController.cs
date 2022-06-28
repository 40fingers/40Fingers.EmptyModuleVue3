using System;
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
using System.Net;
using DotNetNuke.Data;
using DotNetNuke.Security.Permissions;
using FortyFingers.EmptyModuleVue3.Components.BaseClasses;
using FortyFingers.EmptyModuleVue3.Data;
using FortyFingers.EmptyModuleVue3.Services.ViewModels;
using Newtonsoft.Json.Linq;

namespace FortyFingers.EmptyModuleVue3.Services
{
    [SupportedModules("40F EmptyModuleVue3")]
    [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.View)]
    public class ItemController : ApiControllerBase
    {
        public ItemController() { }

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

        [HttpGet]
        [ActionName("GetList")]
        public HttpResponseMessage GetList()
        {
            var retval = new ItemsViewModel();
            var items = new List<Item>();

            using (var dctx = DataContext.Instance())
            {
                var rep = dctx.GetRepository<Item>();
                items = rep.Get().ToList();
            }

            retval.CanEdit = ModulePermissionController.HasModulePermission(ActiveModule.ModulePermissions, "EDIT");

            items.ForEach(i => retval.Items.Add(new ItemViewModel(i)));

            return Request.CreateResponse(retval);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.Edit)]
        [ActionName("Delete")]
        public HttpResponseMessage Delete(int itemId)
        {
            using (var dctx = DataContext.Instance())
            {
                var rep = dctx.GetRepository<Item>();
                rep.Delete($"WHERE {nameof(Item.Id)} = @0", itemId);
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, new { });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.Edit)]
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

        [HttpPost]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage DtProcessing()
        {
            var req = Request.RequestUri.Query;

            return new HttpResponseMessage(HttpStatusCode.OK);
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