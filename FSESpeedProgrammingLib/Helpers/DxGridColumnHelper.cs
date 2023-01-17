using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Mvc.Builders;
using FSESpeedProgrammingLib.Entities;

namespace FSESpeedProgrammingLib.Helpers
{
    public static partial class DxGridHelper
    {
        public static DataGridColumnBuilder<T> AddLookup<T>(this DataGridColumnBuilder<T> builder,
            string lookupController,
            string action,
            string displayExpression,
            string caption,
            object loadParams=null
            )
        {
            return builder
                .Lookup(lookup => lookup
                .DataSource(d
                    => d.Mvc()
                    .Controller(lookupController)
                    .Key("PK")
                    .LoadAction(action)
                    .LoadParams(loadParams)
                    )
                .DisplayExpr(displayExpression)
                .ValueExpr("PK")
                )
                .Caption(caption);
        }

        public static DataGridBuilder<T> AddStandardColumns<T>(this DataGridBuilder<T> builder) where T : BaseClass
        {
            builder.Columns(columns =>
            {
                columns.Add().Caption("System Attributes").Visible(false).Alignment(HorizontalAlignment.Center).Columns(col =>
                {
                    col.AddFor(m => m.PK).Width(80).Visible(false);
                    col.AddFor(m => m.ID).Width(80).Visible(false);
                    col.AddFor(m => m.CreatedOn).Width(145).AllowEditing(false).Format(Constants.DateTimeFormat);
                    col.AddFor(m => m.UpdatedOn).Width(145).AllowEditing(false).Format(Constants.DateTimeFormat);
                    col.AddFor(m => m.CreatedByName).Caption("Created By").Width(100).AllowEditing(false);
                    col.AddFor(m => m.UpdatedByName).Caption("Updated By").Width(100).AllowEditing(false);
                });
            });
            return builder;
        }


    }
}
