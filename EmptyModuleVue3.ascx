<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmptyModuleVue3.ascx.cs" Inherits="POM.EmptyModuleVue3" %>

<script type="text/javascript" src="https://unpkg.com/vue@3"></script>
<link rel="stylesheet" href="/DesktopModules/40Fingers/EmptyModuleVue3/scripts/client-app/css/app.css" />
<link rel="stylesheet" href="https://cdn.datatables.net/1.12.1/css/dataTables.bootstrap4.css" />
<script type="text/javascript" src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap4.js"></script>


<div id="Items-<%= ModuleContext.ModuleId %>">
    <div id="app-<%= ModuleContext.ModuleId %>"
         class="appEmptyModuleVue3"
         data-moduleid="<%= ModuleContext.ModuleId %>"
         data-tabid="<%= ModuleContext.TabId %>"
         data-editmode="<%= ModuleContext.EditMode %>"
         data-apibaseurl="/en-US/DesktopModules/40Fingers/EmptyModuleVue3/API"></div>
</div>

<script type="text/javascript" src="/DesktopModules/40Fingers/EmptyModuleVue3/scripts/client-app/js/chunk-vendors.js"></script>
<script type="text/javascript" src="/DesktopModules/40Fingers/EmptyModuleVue3/scripts/client-app/js/app.js"></script>
<script language="javascript" type="text/javascript">
</script>
test