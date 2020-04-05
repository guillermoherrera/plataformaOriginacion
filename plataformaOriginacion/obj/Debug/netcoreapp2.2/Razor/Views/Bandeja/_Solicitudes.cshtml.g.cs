#pragma checksum "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Solicitudes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24560a0fed7934bb7a51f3ac9074dfa00fcf92f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bandeja__Solicitudes), @"mvc.1.0.view", @"/Views/Bandeja/_Solicitudes.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Bandeja/_Solicitudes.cshtml", typeof(AspNetCore.Views_Bandeja__Solicitudes))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\_ViewImports.cshtml"
using plataformaOriginacion;

#line default
#line hidden
#line 2 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\_ViewImports.cshtml"
using plataformaOriginacion.Models;

#line default
#line hidden
#line 4 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\_ViewImports.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24560a0fed7934bb7a51f3ac9074dfa00fcf92f5", @"/Views/Bandeja/_Solicitudes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13c4d1c73a75ca1b39d8fb86d41013f99381519a", @"/Views/_ViewImports.cshtml")]
    public class Views_Bandeja__Solicitudes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(2, 2835, false);
#line 1 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Solicitudes.cshtml"
Write(Html.DevExtreme().DataGrid<Solicitud>()
        .ShowBorders(true)
        .DataSource(d => d.Mvc().Controller("Bandeja").LoadAction("Get").Key("solicitudID").LoadParams(new { opc = ViewBag.opc }))
        .Selection(s => s.Mode(SelectionMode.Single))
        .ColumnAutoWidth(true)
        .Columns(columns =>
        {
            columns.AddFor(m => m.solicitudID).Visible(false).HidingPriority(0);
            columns.AddFor(m => m.status).CellTemplate(new JS("dataGrid_change_cellTemplate2")).Alignment(HorizontalAlignment.Left).HidingPriority(6).AllowFiltering(false);
            
            columns.AddFor(m => m.sistema).Caption("Sistema").CellTemplate(new JS("dataGrid_change_cellTemplate8")).AllowHeaderFiltering(true).AllowFiltering(false).Alignment(HorizontalAlignment.Center).HidingPriority(2);
            //columns.AddFor(m => m.tipoContrato).CellTemplate(new JS("dataGrid_change_cellTemplate5")).Alignment(HorizontalAlignment.Left).HidingPriority(2).AllowFiltering(false);
            columns.AddFor(m => m.grupoNombre).Caption("Nombre").CellTemplate(new JS("dataGrid_change_cellTemplate6")).HidingPriority(5);
            columns.AddFor(m => m.importe).CellTemplate(new JS("dataGrid_change_cellTemplate4")).Alignment(HorizontalAlignment.Right).HidingPriority(4);
            columns.AddFor(m => m.mesaControlUsuario).Caption("☑ Audita").CellTemplate(new JS("dataGrid_change_cellTemplate7")).Alignment(HorizontalAlignment.Center).HidingPriority(3);
            columns.AddFor(m => m.solicitudID).Caption("Detalle").CellTemplate(new JS("dataGrid_change_cellTemplate")).HidingPriority(7).AllowFiltering(false).Alignment(HorizontalAlignment.Center);
            columns.AddFor(m => m.fechaCaputra).Caption("Fecha").SortOrder(SortOrder.Desc).CellTemplate(new JS("dataGrid_change_cellTemplate3")).Alignment(HorizontalAlignment.Right).HidingPriority(8);
        })
        .Paging(p => p.PageSize(10))
        .FilterRow(f => f.Visible(true))
        .HeaderFilter(f => f.Visible(true))
        .GroupPanel(p => p.Visible(true))
        //.Grouping(g => g.AutoExpandAll(false))
        .RemoteOperations(true)
        .Summary(s => s
            .TotalItems(items =>
            {
                items.AddFor(m => m.importe).SummaryType(SummaryType.Count)
                .CustomizeText(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    BeginContext(2337, 93, true);
    WriteLiteral("\r\n                    function(data) { return \"Solicitudes: \"+data.value; }\r\n                ");
    EndContext();
    PopWriter();
}
));

                
                
                /*items.AddFor(m => m.importe).SummaryType(SummaryType.Sum)
                //.ValueFormat(Format.Currency)
                .CustomizeText(@<text>
                    function(data) { return data.value.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,'); }
                </text>);*/
            })
        )
//.OnSelectionChanged("selection_changed")
);

#line default
#line hidden
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591