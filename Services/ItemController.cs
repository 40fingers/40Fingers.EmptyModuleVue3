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
using System.Data;
using System.Net;
using DotNetNuke.Data;
using DotNetNuke.Security.Permissions;
using FortyFingers.EmptyModuleVue3.Components;
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
        [ActionName("GetConfig")]
        public HttpResponseMessage GetConfig(int itemId)
        {
            var retval = new ModuleConfigModel()
            {
                CanEdit = ModulePermissionController.HasModulePermission(ActiveModule.ModulePermissions, "EDIT")
            };

            return Request.CreateResponse(retval);
        }

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
        public HttpResponseMessage DtProcessing(DatatablesProcessingModel model)
        {
            var retval = new DatatableProcessingResultModel<ItemViewModel>();
            var items = DtSearch(model, out var totalResultsCount, out var filteredResultsCount);

            // retval.CanEdit = ModulePermissionController.HasModulePermission(ActiveModule.ModulePermissions, "EDIT");
            var retvalData = new List<ItemViewModel>();
            items.ForEach(i => retvalData.Add(new ItemViewModel(i)));
            retval.Data = retvalData;
            retval.Draw = model.draw;
            retval.RecordsTotal = totalResultsCount;
            retval.RecordsFiltered = filteredResultsCount;

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, retval);
        }

        private List<Item> DtSearch(DatatablesProcessingModel model, 
            out int totalResultsCount,
            out int filteredResultsCount)
        {
            List<Item> retval = null;
            using (var dctx = DataContext.Instance())
            {
                var rep = dctx.GetRepository<Item>();

                var whereClause = $"{nameof(Item.ModuleId)}=@0";
                // get the total number of records
                totalResultsCount = dctx.ExecuteScalar<int>(CommandType.Text, $"SELECT COUNT(*) FROM {Common.GetTableName<Item>()} WHERE {whereClause}", ActiveModule.ModuleID);

                if (!string.IsNullOrWhiteSpace(model.search?.value))
                {
                    var searchValue = PortalSecurity.Instance.InputFilter(model.search.value, PortalSecurity.FilterFlag.NoSQL);

                    whereClause +=
                        $" AND ({nameof(Item.ItemName)} LIKE '%{string.IsNullOrWhiteSpace(searchValue)}%' OR {nameof(Item.ItemDescription)} LIKE ItemName LIKE '%{string.IsNullOrWhiteSpace(searchValue)}%')";
                }
                // get the filtered number of records
                filteredResultsCount = dctx.ExecuteScalar<int>(CommandType.Text, $"SELECT COUNT(*) FROM {Common.GetTableName<Item>()} WHERE {whereClause}", ActiveModule.ModuleID);

                // get the items
                var pageSize = model.length;
                var pageIndex = model.start == 0 ? 0 : (int)Math.Floor((decimal)model.start / pageSize);
                retval = rep.Find(pageIndex, pageSize, $"WHERE {whereClause}", ActiveModule.ModuleID).ToList();
            }

            return retval;
        }
    }
}