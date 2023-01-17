using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Mvc.Builders;
using FSESpeedProgrammingLib.Entities;

namespace FSESpeedProgrammingLib.Helpers
{
    public static partial class DxGridHelper
    {
        public static DataGridBuilder<T> Readonly<T>(this DataGridBuilder<T> builder)

        {
            return builder.Editing(e => e.AllowAdding(false).AllowDeleting(false).AllowUpdating(false));
        }

        public static DataGridBuilder<object> BuildForView(this DataGridBuilder<object> builder,
            string controllerName,
            string getMethod,
            int? pageSize,
            object loadParams = null,
            string height = ""
            )
        {
            Setup<object>(builder, controllerName, getMethod, pageSize, loadParams).Height(height);
            return builder;
        }

        /// <summary>
        /// Initla AllowAdding(false) 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="controllerName"></param>
        /// <param name="getMethod"></param>
        /// <param name="pageSize"></param>
        /// <param name="loadParams"></param>
        /// <param name="height"></param>
        /// <param name="enableEdit"></param>
        /// <returns></returns>
        public static DataGridBuilder<T> BuildChild<T>(this DataGridBuilder<T> builder,
        string controllerName,
        string getMethod,
        int? pageSize,
        object loadParams = null,
        string height = "",
        bool enableEdit = true
        ) where T : BaseClass
        {
            Setup<T>(builder, controllerName, getMethod, pageSize, loadParams)
                .Height(height)
                .Editing(e => e
                    .AllowAdding(false)
                    .AllowUpdating(enableEdit)
                    .AllowDeleting(enableEdit)
                    .UseIcons(enableEdit));
            return builder;
        }

        public static DataGridBuilder<T> Build<T>(this DataGridBuilder<T> builder,
            string controllerName,
            string getMethod,
            int? pageSize
            ) where T : BaseClass
        {
            return Build<T>(builder, controllerName, getMethod, pageSize, string.Empty, "100%");
        }

        public static DataGridBuilder<T> Build<T>(this DataGridBuilder<T> builder,
            string controllerName,
            string getMethod
            ) where T : BaseClass
        {
            return Build<T>(builder, controllerName, getMethod, 20, null);
        }

        public static DataGridBuilder<T> Build<T>(this DataGridBuilder<T> builder,
            string controllerName,
            string getMethod,
            int? pageSize,
            object loadParams = null
            ) where T : BaseClass
        {
            return Build<T>(builder, controllerName, getMethod, pageSize, loadParams, "100%");
        }

        public static DataGridBuilder<T> Build<T>(this DataGridBuilder<T> builder,
        string controllerName,
        string getMethod,
        int? pageSize,
        object loadParams = null,
        string height = "",
        bool enableEdit = true
        ) where T : BaseClass
        {
            builder = Setup<T>(builder, controllerName, getMethod, pageSize, loadParams)
                .Height(height)
                .Editing(e => e.AllowAdding(enableEdit).AllowUpdating(enableEdit).AllowDeleting(enableEdit).UseIcons(enableEdit));
            return builder;
        }

        private static DataGridBuilder<T> Setup<T>(DataGridBuilder<T> builder, string controllerName, string getMethod, int? pageSize, object loadParams)
        {
            builder
                .ShowBorders(true)
                .Width("100%")
                .AllowColumnResizing(true)
                .AllowColumnReordering(true)
                .ColumnResizingMode(ColumnResizingMode.Widget)
                .ColumnChooser(c => c.Enabled(true))
                .ColumnFixing(f => f.Enabled(true))
                .DataSource(d => d.Mvc()
                    .Key("PK")
                    .Controller(controllerName)
                    .LoadAction(getMethod)
                    .InsertAction("Insert")
                    .UpdateAction("Update")
                    .DeleteAction("Delete")
                    .LoadParams(loadParams)
                 )
                .RemoteOperations(r => r.Filtering(true).Sorting(true).Grouping(true).GroupPaging(true))
                //.Export(e => e.AllowExportSelectedData(true))
                .Selection(s => s.Mode(SelectionMode.Multiple))
                .Export(e => e.Enabled(true).AllowExportSelectedData(true))
                .HoverStateEnabled(true)
                //.RemoteOperations(r => r.Filtering(true).Sorting(true).Grouping(true))
                .FocusedRowEnabled(true)
                .FilterRow(f => f.Visible(true))
                .GroupPanel(gp => gp.Visible(true))
                .HeaderFilter(f => f.Visible(true))
                .ShowColumnLines(true)
                .StateStoring(s => s
                    .Enabled(true)
                    .Type(StateStoringType.LocalStorage)
                    .StorageKey("storage")
                );

            if (pageSize != null)
                builder
                    .Paging(p => { p.Enabled(true); p.PageSize(pageSize.Value); })
                    .Pager(pager =>
                    {
                        pager.ShowPageSizeSelector(true);
                        pager.AllowedPageSizes(new[] { 10, 20, 30, 50 });
                        pager.ShowInfo(true);
                    })
                    //.Selection(s => s.Mode(SelectionMode.Multiple))
                    //.Export(e => e.Enabled(true).AllowExportSelectedData(true))
            ;
            return builder;
        }

        public static DataGridBuilder<T> BuildPartialEdit<T>(this DataGridBuilder<T> builder,
            string controllerName,
            string getMethod,
            int? pageSize
            ) where T : BaseClass
                {
                    return BuildPartialEdit<T>(builder, controllerName, getMethod, pageSize, string.Empty, "100%");
                }
        public static DataGridBuilder<T> BuildPartialEdit<T>(this DataGridBuilder<T> builder,
            string controllerName,
            string getMethod,
            int? pageSize,
            object loadParams = null
            ) where T : BaseClass
        {
            return BuildPartialEdit<T>(builder, controllerName, getMethod, pageSize, loadParams, "100%");
        }

        public static DataGridBuilder<T> BuildPartialEdit<T>(this DataGridBuilder<T> builder,
        string controllerName,
        string getMethod,
        int? pageSize,
        object loadParams = null,
        string height = "",
        bool enableEdit = true
        ) where T : BaseClass
        {
            builder = Setups<T>(builder, controllerName, getMethod, pageSize, loadParams)
                .Height(height)
             //.Editing(e => e.AllowAdding(enableEdit).AllowUpdating(enableEdit).AllowDeleting(enableEdit).UseIcons(enableEdit));
             .Editing(editing =>
              {
                  editing.Mode(GridEditMode.Popup);
                  editing.AllowAdding(true);
                  editing.AllowUpdating(true);
                  editing.AllowUpdating(new JS("allowUpdating"));
                  editing.AllowDeleting(true);
                  editing.AllowDeleting(new JS("allowDeleting"));
                  editing.UseIcons(true);
              });
            return builder;
        }

        private static DataGridBuilder<T> Setups<T>(DataGridBuilder<T> builder, string controllerName, string getMethod, int? pageSize, object loadParams)
        {
            builder
                .ShowBorders(true)
                .Width("100%")
                .AllowColumnResizing(true)
                .AllowColumnReordering(true)
                .ColumnResizingMode(ColumnResizingMode.Widget)
                .ColumnChooser(c => c.Enabled(true))
                .ColumnFixing(f => f.Enabled(true))
                .DataSource(d => d.Mvc()
                    .Key("PK")
                    .Controller(controllerName)
                    .LoadAction(getMethod)
                    .InsertAction("Insert")
                    .UpdateAction("Update")
                    .DeleteAction("Delete")
                    .LoadParams(loadParams)
                 )
                .RemoteOperations(r => r.Filtering(true).Sorting(true).Grouping(true).GroupPaging(true))
                //.Export(e => e.AllowExportSelectedData(true))
                .Selection(s => s.Mode(SelectionMode.Multiple))
                .Export(e => e.Enabled(true).AllowExportSelectedData(true))
                .HoverStateEnabled(true)
                //.RemoteOperations(r => r.Filtering(true).Sorting(true).Grouping(true))
                .FocusedRowEnabled(true)
                .FilterRow(f => f.Visible(true))
                .GroupPanel(gp => gp.Visible(true))
                .HeaderFilter(f => f.Visible(true))
                .ShowColumnLines(true)
                .StateStoring(s => s
                    .Enabled(true)
                    .Type(StateStoringType.LocalStorage)
                    .StorageKey("storage")
                );

            if (pageSize != null)
                builder
                    .Paging(p => { p.Enabled(true); p.PageSize(pageSize.Value); })
                    .Pager(pager =>
                    {
                        pager.ShowPageSizeSelector(true);
                        pager.AllowedPageSizes(new[] { 10, 20, 30, 50 });
                        pager.ShowInfo(true);
                    })
            //.Selection(s => s.Mode(SelectionMode.Multiple))
            //.Export(e => e.Enabled(true).AllowExportSelectedData(true))
            ;
            return builder;
        }
    }
}
