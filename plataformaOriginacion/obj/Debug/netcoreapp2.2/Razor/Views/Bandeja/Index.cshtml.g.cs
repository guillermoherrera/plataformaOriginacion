#pragma checksum "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8111f2b3172359c0f7eb23ed48f685d6e428f02"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bandeja_Index), @"mvc.1.0.view", @"/Views/Bandeja/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Bandeja/Index.cshtml", typeof(AspNetCore.Views_Bandeja_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8111f2b3172359c0f7eb23ed48f685d6e428f02", @"/Views/Bandeja/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13c4d1c73a75ca1b39d8fb86d41013f99381519a", @"/Views/_ViewImports.cshtml")]
    public class Views_Bandeja_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Solicitudes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\Index.cshtml"
  
    ViewData["Title"] = "Bandeja";

#line default
#line hidden
            BeginContext(43, 335, true);
            WriteLiteral(@"<div class=""container "" style=""margin:1em;"">
    <div class=""col-md-12 row"" style=""background-color: #e5e5e5;padding:1em;border-radius: 25px;opacity: .9;"">
        <div class=""col-md-4 col-md-offset-5""></div>
        <h1><label><strong style=""font-size: smaller;"">Bandeja de Solicitudes</strong></label></h1>
    </div>
</div>

");
            EndContext();
#line 11 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\Index.cshtml"
 if (ViewBag.errores == null)
{

#line default
#line hidden
            BeginContext(412, 128, true);
            WriteLiteral("    <div style=\"padding:1em;background-color:white;border-radius: 25px;opacity: .9;\">\r\n        <div id=\"div_grid\">\r\n            ");
            EndContext();
            BeginContext(540, 31, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a8111f2b3172359c0f7eb23ed48f685d6e428f024719", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(571, 886, true);
            WriteLiteral(@"
        </div>
        <div style=""padding:1em;"" align=""right"">
            <div>
                Los datos de la bandeja se actualizarán en <span id=""time"">10:00</span> minutos <a href=""#"" onClick=""return false;"" id=""btn_restart"" text=""DETENER"" data-toggle=""tooltip"" title=""PAUSAR / REANUDAR""><span id=""ctr_timer"" class=""flaticon-pause-symbol"" style=""position: relative;margin-left: -20px;""></span></a> .
                Para actualizar los datos manualmente da clic aquí
                <a href=""#"" onClick=""return false;"" id=""btn_cargar"" data-toggle=""tooltip"" title=""RECARGAR DATOS""><span class=""flaticon-update-arrow"" style=""position: relative;margin-left: -20px;""></span></a>.
            </div>
            <div style=""font-size:.8em;"">
                *<strong><i style=""color:brown;"">(R)</i></strong><i> Renovacón.</i>
            </div>
        </div>
    </div>
");
            EndContext();
#line 28 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\Index.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(1469, 105, true);
            WriteLiteral("    <div style=\"padding:1em;background-color:white;border-radius: 25px;\">\r\n        <h1 style=\"color:red\">");
            EndContext();
            BeginContext(1575, 15, false);
#line 32 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\Index.cshtml"
                         Write(ViewBag.errores);

#line default
#line hidden
            EndContext();
            BeginContext(1590, 19, true);
            WriteLiteral("</h1>\r\n    </div>\r\n");
            EndContext();
#line 34 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1612, 26532, true);
            WriteLiteral(@"

<script>
    function dataGrid_change_cellTemplate(element, info) {
        var data = info.data;
        var ext = data.tipoContrato == 1 ? ""Detalle/?_ID="" + data.solicitudID : ""DetalleGrupo/?_ID="" + data.grupoID;
        if (data.renovacion) {
            element.html(""<center><a href='/Bandeja/Renovacion"" + ext + ""' target='_blank'>VER</a></center>"");
        } else {
            element.html(""<center><a href='/Bandeja/"" + ext + ""' target='_blank'>VER</a></center>"");
        }
    }
    function dataGrid_change_cellTemplate2(element, info) {
        var data = info.data;
        switch (data.status) {
            case 2:
                clase = 'success';
                label = 'DICTAMINADO';
                break;
            case 3:
                clase = 'danger';
                label = 'RECHAZADO';
                break;
            case 6:
                clase = 'warning';
                label = 'REVISIÓN';
                break;
            case 7:
                c");
            WriteLiteral(@"lase = 'info';
                label = 'EN ESPERA C. DE BURÓ';
                break;
            case 8:
                clase = 'info';
                label = 'EN PROCESO C. DE BURÓ';
                break;
            case 9:
                clase = 'primary';
                label = 'POR DICTAMINAR';
                break;
            case 10:
                clase = 'danger';
                label = 'ERROR EN C. DE BURÓ';
                break;
            case 98:
                clase = 'secondary';
                label = 'GRUPO EN ESPERA';
                break;
            case 99:
                clase = 'primary';
                label = 'GRUPO POR DICTAMINAR';
                break;
            case 100:
                clase = 'danger';
                label = 'GRUPO RECHAZADO';
                break;
            case 101:
                clase = 'success';
                label = 'GRUPO APROBADO';
                break;
            default:
                clase");
            WriteLiteral(@" = 'secondary';
                label = 'POR AUTORIZAR C. DE BURÓ';
                break;
        }
        //var clase = data.status == 2 ? 'success' : data.status == 3 ? 'danger' : data.status == 6 || data.status == 6 ? 'warning' : 'primary';
        //var label = data.status == 2 ? 'APROBADO' : data.status == 3 ? 'DENEGADO' : data.status == 6 || data.status == 6 ? 'REVISION' : 'POR AUTORIZAR';
        element.html(""<span class='badge badge-"" + clase + ""'>"" + label + ""</span>"");
        if (data.cambios > 0) {
            element.append("" <span class='badge badge-warning' title='Solicitudes de cambio de Documentos Pendientes.'>"" + data.cambios + ""</span>"");
        }
    }
    function dataGrid_change_cellTemplate3(element, info) {
        var data = info.data;

        var clase = data.status == ""DICTAMINADO"" ? 'success' : data.status == ""RECHAZADO"" ? 'danger' : data.status == ""REVISION"" || data.status == ""REVISIÓN"" ? 'warning' : 'primary';

        //var options = { weekday: 'short', year");
            WriteLiteral(@": 'numeric', month: 'short', day: '2-digit', hour: '2-digit', minute: '2-digit', second: '2-digit' };
        var options = { month: 'short', day: 'numeric' };
        var fecha = new Date(data.fechaCaputra).toLocaleDateString(""es-MX"", options);
        var x = window.matchMedia(""(max-width: 700px)"");
        if (x.matches) {
            element.html(""<span class='badge badge-"" + clase + ""'>*</span>"");// + "" <span><i>"" + fecha.toString() + ""</i></span>"");
            element.append("" <span><strong><i>"" + fecha.toString() + ""</i></strong></span>"");
            if (data.cambios > 0) {
                element.append("" <span class='badge badge-warning' title='Solicitudes de cambio de Documentos Pendientes.'>"" + data.cambios + ""</span>"");
            }
        } else {
            element.html(""<span><strong><i>"" + fecha.toString() + ""</i></strong></span>"");
        }
    }
    function dataGrid_change_cellTemplate4(element, info) {
        var data = info.data;
        var monto = (data.importe).t");
            WriteLiteral(@"oFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        element.html(""<span><i>"" + monto + ""</i></span>"");
    }
    function dataGrid_change_cellTemplate5(element, info) {
        var data = info.data;

        //var label = data.tipoContrato == 1 ? ""INDIVIDUAL"" : data.tipoContrato == 2 ? ""GRUPAL"" : ""Sin Especificar"";
        var label = data.tipoContrato == 1 ? ""<span class='flaticon-man-user' style='position: relative; margin-left: -20px;color: black;'><i> INDIVIDUAL</i></span>"" : data.tipoContrato == 2 ? ""<span class='flaticon-users-group' style='position: relative; margin-left: -20px;color: black;'><i> GRUPAL</i></span>"" : ""<span class='flaticon-pause-symbol' style='position: relative; margin-left: -20px;color: green;'><i> Sin especificar</i></span>"";

        element.html(label);
    }
    function dataGrid_change_cellTemplate6(element, info) {
        var data = info.data;
        var label;
        if (data.grupoID == null) {
            label = (data.renovacion ? ""<strong> (R)  </strong");
            WriteLiteral(@">"" : """") + data.persona.nombre + "" "" + data.persona.nombreSegundo + "" "" + data.persona.apellido + "" "" + data.persona.apellidoSegundo
        } else {
            label = (data.renovacion ? ""<strong> (R)  </strong>"" : """") + data.grupoNombre
        }
        var label2 = data.tipoContrato == 1 ? ""<span class='flaticon-man-user' style='position: relative; margin-left: -20px;color: black;'><i> "" + label + ""</i></span>"" : data.tipoContrato == 2 ? ""<span class='flaticon-users-group' style='position: relative; margin-left: -20px;color: "" + (data.renovacion ? ""darkslategray"" : ""black"") + "";'><i> "" + label +""</i></span>"" : ""<span class='flaticon-pause-symbol' style='position: relative; margin-left: -20px;color: green;'><i> Sin especificar</i></span>"";

        element.html(label2);
    }

    function dataGrid_change_cellTemplate7(element, info) {
        var data = info.data;
        var label = data.mesaControlUsuario;
        if (label != null) {
            label = label.replace(/ .*/, '');
        ");
            WriteLiteral(@"} else {
            label = """";
        }
        element.html(""<span><i>"" + label + ""</i></span>"");
    }

    function dataGrid_change_cellTemplate8(element, info) {
        var data = info.data;
        var sistema = data.sistema;
        var label;

        switch (sistema) {
            case 1:
                label = ""VR""
                break;
            case 2:
                label = ""OPOR""
                break;
            case 3:
                label = ""CRECE""
                break;
            case 4:
                label = ""GYT""
                break;
            default:
                label = ""N/D""
        }

        element.html(""<span><i>"" + label + ""</i></span>"");
    }
</script>

<script>
    $(document).ready(function () {
        var timer = 60 * 10, minutes, seconds;
        var display = document.querySelector('#time');
        var rotate = function () {
            minutes = parseInt(timer / 60, 10)
            seconds = parseInt(timer % 60, ");
            WriteLiteral(@"10);

            minutes = minutes < 10 ? ""0"" + minutes : minutes;
            seconds = seconds < 10 ? ""0"" + seconds : seconds;

            display.textContent = minutes + "":"" + seconds;

            if (--timer < 0) {
                timer = 60 * 10;
                $(""#div_grid"").load('/Bandeja/PartialViews');
            }
        };
        intervalID = setInterval(rotate, 1000);

        $(""#btn_cargar"").click(function () {
            $(""#div_grid"").load('/Bandeja/PartialViews');
        });

        $(""#btn_restart"").click(function () {
            console.log($(this).attr('text'));
            var accion = $(this).attr('text');
            if (accion == 'DETENER') {
                clearInterval(intervalID);
                $(this).attr('text', 'INICIAR');
                $(""#ctr_timer"").removeClass(""flaticon-pause-symbol"");
                $(""#ctr_timer"").addClass(""flaticon-play-button"");
            } else {
                intervalID = setInterval(rotate, 1000);
     ");
            WriteLiteral(@"           $(this).attr('text', 'DETENER');
                $(""#ctr_timer"").addClass(""flaticon-pause-symbol"");
                $(""#ctr_timer"").removeClass(""flaticon-play-button"");
            }
        });
    });
</script>

<script>
    /*!
    * DevExtreme (dx.messages.de.js)
    * Version: 19.1.4
    * Build date: Mon Jun 17 2019
    *
    * Copyright (c) 2012 - 2019 Developer Express Inc. ALL RIGHTS RESERVED
    * Read about DevExtreme licensing here: https://js.devexpress.com/Licensing/
    */
    ""use strict"";

    ! function (root, factory) {
        if (""function"" === typeof define && define.amd) {
            define(function (require) {
                factory(require(""devextreme/localization""))
            })
        } else {
            if (""object"" === typeof module && module.exports) {
                factory(require(""devextreme/localization""))
            } else {
                factory(DevExpress.localization)
            }
        }
    }(this, function (localiz");
            WriteLiteral(@"ation) {
        localization.loadMessages({
            en: {
                Yes: ""S\xed"",
                No: ""No"",
                Cancel: ""Cancelar"",
                Clear: ""Limpiar"",
                Done: ""Hecho"",
                Loading: ""Cargando..."",
                Select: ""Seleccionar..."",
                Search: ""Buscar"",
                Back: ""Volver"",
                OK: ""Aceptar"",
                ""dxCollectionWidget-noDataText"": ""Sin datos para mostrar"",
                ""validation-required"": ""Obligatorio"",
                ""validation-required-formatted"": ""{0} es obligatorio"",
                ""validation-numeric"": ""Valor debe ser un n\xfamero"",
                ""validation-numeric-formatted"": ""{0} debe ser un n\xfamero"",
                ""validation-range"": ""Valor fuera de rango"",
                ""validation-range-formatted"": ""{0} fuera de rango"",
                ""validation-stringLength"": ""El tama\xf1o del valor es incorrecto"",
                ""validation-stringLength-format");
            WriteLiteral(@"ted"": ""El tama\xf1o de {0} es incorrecto"",
                ""validation-custom"": ""Valor inv\xe1lido"",
                ""validation-custom-formatted"": ""{0} inv\xe1lido"",
                ""validation-compare"": ""Valores no coinciden"",
                ""validation-compare-formatted"": ""{0} no coinciden"",
                ""validation-pattern"": ""Valor no coincide con el patr\xf3n"",
                ""validation-pattern-formatted"": ""{0} no coincide con el patr\xf3n"",
                ""validation-email"": ""Email inv\xe1lido"",
                ""validation-email-formatted"": ""{0} inv\xe1lido"",
                ""validation-mask"": ""Valor inv\xe1lido"",
                ""dxLookup-searchPlaceholder"": ""Cantidad m\xednima de caracteres: {0}"",
                ""dxList-pullingDownText"": ""Desliza hacia abajo para actualizar..."",
                ""dxList-pulledDownText"": ""Suelta para actualizar..."",
                ""dxList-refreshingText"": ""Actualizando..."",
                ""dxList-pageLoadingText"": ""Cargando..."",
                ");
            WriteLiteral(@"""dxList-nextButtonText"": ""M\xe1s"",
                ""dxList-selectAll"": ""Seleccionar Todo"",
                ""dxListEditDecorator-delete"": ""Eliminar"",
                ""dxListEditDecorator-more"": ""M\xe1s"",
                ""dxScrollView-pullingDownText"": ""Desliza hacia abajo para actualizar..."",
                ""dxScrollView-pulledDownText"": ""Suelta para actualizar..."",
                ""dxScrollView-refreshingText"": ""Actualizando..."",
                ""dxScrollView-reachBottomText"": ""Cargando..."",
                ""dxDateBox-simulatedDataPickerTitleTime"": ""Seleccione hora"",
                ""dxDateBox-simulatedDataPickerTitleDate"": ""Seleccione fecha"",
                ""dxDateBox-simulatedDataPickerTitleDateTime"": ""Seleccione fecha y hora"",
                ""dxDateBox-validation-datetime"": ""Valor debe ser una fecha u hora"",
                ""dxFileUploader-selectFile"": ""Seleccionar archivo"",
                ""dxFileUploader-dropFile"": ""o arrastre un archivo aqu\xed"",
                ""dxFileUploader-bytes"": ");
            WriteLiteral(@"""bytes"",
                ""dxFileUploader-kb"": ""kb"",
                ""dxFileUploader-Mb"": ""Mb"",
                ""dxFileUploader-Gb"": ""Gb"",
                ""dxFileUploader-upload"": ""Subir"",
                ""dxFileUploader-uploaded"": ""Subido"",
                ""dxFileUploader-readyToUpload"": ""Listo para subir"",
                ""dxFileUploader-uploadFailedMessage"": ""Falla ao subir"",
                ""dxFileUploader-invalidFileExtension"": ""Tipo de archivo no est\xe1 permitido"",
                ""dxFileUploader-invalidMaxFileSize"": ""Archivo es muy grande"",
                ""dxFileUploader-invalidMinFileSize"": ""Archivo es muy peque\xf1o"",
                ""dxRangeSlider-ariaFrom"": ""Desde"",
                ""dxRangeSlider-ariaTill"": ""Hasta"",
                ""dxSwitch-switchedOnText"": ""ENCENDIDO"",
                ""dxSwitch-switchedOffText"": ""APAGADO"",
                ""dxForm-optionalMark"": ""opcional"",
                ""dxForm-requiredMessage"": ""{0} es obligatorio"",
                ""dxNumberBox-invalidValueMe");
            WriteLiteral(@"ssage"": ""Valor debe ser un n\xfamero"",
                ""dxDataGrid-columnChooserTitle"": ""Selector de Columnas"",
                ""dxDataGrid-columnChooserEmptyText"": ""Arrastra una columna aqu\xed para ocultarla"",
                ""dxDataGrid-groupContinuesMessage"": ""Contin\xfaa en la p\xe1gina siguiente"",
                ""dxDataGrid-groupContinuedMessage"": ""Continuaci\xf3n de la p\xe1gina anterior"",
                ""dxDataGrid-groupHeaderText"": ""Agrupar por esta columna"",
                ""dxDataGrid-ungroupHeaderText"": ""Desagrupar"",
                ""dxDataGrid-ungroupAllText"": ""Desagrupar Todo"",
                ""dxDataGrid-editingEditRow"": ""Modificar"",
                ""dxDataGrid-editingSaveRowChanges"": ""Guardar"",
                ""dxDataGrid-editingCancelRowChanges"": ""Cancelar"",
                ""dxDataGrid-editingDeleteRow"": ""Eliminar"",
                ""dxDataGrid-editingUndeleteRow"": ""Recuperar"",
                ""dxDataGrid-editingConfirmDeleteMessage"": ""\xbfEst\xe1 seguro que desea eliminar este ");
            WriteLiteral(@"registro?"",
                ""dxDataGrid-validationCancelChanges"": ""Cancelar cambios"",
                ""dxDataGrid-groupPanelEmptyText"": ""Arrastra una columna aqu\xed para agrupar por ella"",
                ""dxDataGrid-noDataText"": ""Sin datos"",
                ""dxDataGrid-searchPanelPlaceholder"": ""Buscar..."",
                ""dxDataGrid-filterRowShowAllText"": ""(Todos)"",
                ""dxDataGrid-filterRowResetOperationText"": ""Reestablecer"",
                ""dxDataGrid-filterRowOperationEquals"": ""Igual"",
                ""dxDataGrid-filterRowOperationNotEquals"": ""No es igual"",
                ""dxDataGrid-filterRowOperationLess"": ""Menor que"",
                ""dxDataGrid-filterRowOperationLessOrEquals"": ""Menor o igual a"",
                ""dxDataGrid-filterRowOperationGreater"": ""Mayor que"",
                ""dxDataGrid-filterRowOperationGreaterOrEquals"": ""Mayor o igual a"",
                ""dxDataGrid-filterRowOperationStartsWith"": ""Empieza con"",
                ""dxDataGrid-filterRowOperationContains""");
            WriteLiteral(@": ""Contiene"",
                ""dxDataGrid-filterRowOperationNotContains"": ""No contiene"",
                ""dxDataGrid-filterRowOperationEndsWith"": ""Termina con"",
                ""dxDataGrid-filterRowOperationBetween"": ""Entre"",
                ""dxDataGrid-filterRowOperationBetweenStartText"": ""Inicio"",
                ""dxDataGrid-filterRowOperationBetweenEndText"": ""Fin"",
                ""dxDataGrid-applyFilterText"": ""Filtrar"",
                ""dxDataGrid-trueText"": ""verdadero"",
                ""dxDataGrid-falseText"": ""falso"",
                ""dxDataGrid-sortingAscendingText"": ""Orden Ascendente"",
                ""dxDataGrid-sortingDescendingText"": ""Orden Descendente"",
                ""dxDataGrid-sortingClearText"": ""Limpiar Ordenamiento"",
                ""dxDataGrid-editingSaveAllChanges"": ""Guardar cambios"",
                ""dxDataGrid-editingCancelAllChanges"": ""Descartar cambios"",
                ""dxDataGrid-editingAddRow"": ""Agregar una fila"",
                ""dxDataGrid-summaryMin"": ""M\xedn: {0}"",");
            WriteLiteral(@"
                ""dxDataGrid-summaryMinOtherColumn"": ""M\xedn de {1} es {0}"",
                ""dxDataGrid-summaryMax"": ""M\xe1x: {0}"",
                ""dxDataGrid-summaryMaxOtherColumn"": ""M\xe1x de {1} es {0}"",
                ""dxDataGrid-summaryAvg"": ""Prom: {0}"",
                ""dxDataGrid-summaryAvgOtherColumn"": ""Prom de {1} es {0}"",
                ""dxDataGrid-summarySum"": ""Suma: {0}"",
                ""dxDataGrid-summarySumOtherColumn"": ""Suma de {1} es {0}"",
                ""dxDataGrid-summaryCount"": ""Cantidad: {0}"",
                ""dxDataGrid-columnFixingFix"": ""Anclar"",
                ""dxDataGrid-columnFixingUnfix"": ""Desanclar"",
                ""dxDataGrid-columnFixingLeftPosition"": ""A la izquierda"",
                ""dxDataGrid-columnFixingRightPosition"": ""A la derecha"",
                ""dxDataGrid-exportTo"": ""Exportar"",
                ""dxDataGrid-exportToExcel"": ""Exportar a archivo Excel"",
                ""dxDataGrid-excelFormat"": ""Archivo Excel"",
                ""dxDataGrid-selectedRow");
            WriteLiteral(@"s"": ""Filas seleccionadas"",
                ""dxDataGrid-exportSelectedRows"": ""Exportar filas seleccionadas"",
                ""dxDataGrid-exportAll"": ""Exportar todo"",
                ""dxDataGrid-headerFilterEmptyValue"": ""(Vacio)"",
                ""dxDataGrid-headerFilterOK"": ""Aceptar"",
                ""dxDataGrid-headerFilterCancel"": ""Cancelar"",
                ""dxDataGrid-ariaColumn"": ""Columna"",
                ""dxDataGrid-ariaValue"": ""Valor"",
                ""dxDataGrid-ariaFilterCell"": ""Celda de filtro"",
                ""dxDataGrid-ariaCollapse"": ""Colapsar"",
                ""dxDataGrid-ariaExpand"": ""Expandir"",
                ""dxDataGrid-ariaDataGrid"": ""Tabla de datos"",
                ""dxDataGrid-ariaSearchInGrid"": ""Buscar en la tabla de datos"",
                ""dxDataGrid-ariaSelectAll"": ""Seleccionar todo"",
                ""dxDataGrid-ariaSelectRow"": ""Seleccionar fila"",
                ""dxDataGrid-filterBuilderPopupTitle"": ""Constructor de filtro"",
                ""dxDataGrid-filterPanelCrea");
            WriteLiteral(@"teFilter"": ""Crear filtro"",
                ""dxDataGrid-filterPanelClearFilter"": ""Limpiar filtro"",
                ""dxDataGrid-filterPanelFilterEnabledHint"": ""Habilitar filtro"",
                ""dxTreeList-ariaTreeList"": ""Lista de \xe1rbol"",
                ""dxTreeList-editingAddRowToNode"": ""A\xf1adir"",
                ""dxPager-infoText"": ""P\xe1gina {0} de {1} ({2} \xedtems)"",
                ""dxPager-pagesCountText"": ""de"",
                ""dxPivotGrid-grandTotal"": ""Gran Total"",
                ""dxPivotGrid-total"": ""{0} Total"",
                ""dxPivotGrid-fieldChooserTitle"": ""Selector de Campos"",
                ""dxPivotGrid-showFieldChooser"": ""Mostrar Selector de Campos"",
                ""dxPivotGrid-expandAll"": ""Expandir Todo"",
                ""dxPivotGrid-collapseAll"": ""Colapsar Todo"",
                ""dxPivotGrid-sortColumnBySummary"": 'Ordenar ""{0}"" por esta columna',
                ""dxPivotGrid-sortRowBySummary"": 'Ordenar ""{0}"" por esta fila',
                ""dxPivotGrid-removeAllSorting");
            WriteLiteral(@""": ""Remover ordenamiento"",
                ""dxPivotGrid-dataNotAvailable"": ""N/A"",
                ""dxPivotGrid-rowFields"": ""Campos de fila"",
                ""dxPivotGrid-columnFields"": ""Campos de columna"",
                ""dxPivotGrid-dataFields"": ""Campos de dato"",
                ""dxPivotGrid-filterFields"": ""Campos de filtro"",
                ""dxPivotGrid-allFields"": ""Todos los campos"",
                ""dxPivotGrid-columnFieldArea"": ""Arrastra campos de columna aqu\xed"",
                ""dxPivotGrid-dataFieldArea"": ""Arrastra campos de dato aqu\xed"",
                ""dxPivotGrid-rowFieldArea"": ""Arrastra campos de fila aqu\xed"",
                ""dxPivotGrid-filterFieldArea"": ""Arrastra campos de filtro aqu\xed"",
                ""dxScheduler-editorLabelTitle"": ""Asunto"",
                ""dxScheduler-editorLabelStartDate"": ""Fecha inicial"",
                ""dxScheduler-editorLabelEndDate"": ""Fecha final"",
                ""dxScheduler-editorLabelDescription"": ""Descripci\xf3n"",
                ""dxSchedul");
            WriteLiteral(@"er-editorLabelRecurrence"": ""Repetir"",
                ""dxScheduler-openAppointment"": ""Abrir cita"",
                ""dxScheduler-recurrenceNever"": ""Nunca"",
                ""dxScheduler-recurrenceDaily"": ""Diario"",
                ""dxScheduler-recurrenceWeekly"": ""Semanal"",
                ""dxScheduler-recurrenceMonthly"": ""Mensual"",
                ""dxScheduler-recurrenceYearly"": ""Anual"",
                ""dxScheduler-recurrenceRepeatEvery"": ""Cada"",
                ""dxScheduler-recurrenceRepeatOn"": ""Repeat On"",
                ""dxScheduler-recurrenceEnd"": ""Terminar repetici\xf3n"",
                ""dxScheduler-recurrenceAfter"": ""Despu\xe9s"",
                ""dxScheduler-recurrenceOn"": ""En"",
                ""dxScheduler-recurrenceRepeatDaily"": ""d\xeda(s)"",
                ""dxScheduler-recurrenceRepeatWeekly"": ""semana(s)"",
                ""dxScheduler-recurrenceRepeatMonthly"": ""mes(es)"",
                ""dxScheduler-recurrenceRepeatYearly"": ""a\xf1o(s)"",
                ""dxScheduler-switcherDay"": ""D\xe");
            WriteLiteral(@"da"",
                ""dxScheduler-switcherWeek"": ""Semana"",
                ""dxScheduler-switcherWorkWeek"": ""Semana Laboral"",
                ""dxScheduler-switcherMonth"": ""Mes"",
                ""dxScheduler-switcherAgenda"": ""Agenda"",
                ""dxScheduler-switcherTimelineDay"": ""L\xednea de tiempo D\xeda"",
                ""dxScheduler-switcherTimelineWeek"": ""L\xednea de tiempo Semana"",
                ""dxScheduler-switcherTimelineWorkWeek"": ""L\xednea de tiempo Semana Laboral"",
                ""dxScheduler-switcherTimelineMonth"": ""L\xednea de tiempo Mes"",
                ""dxScheduler-recurrenceRepeatOnDate"": ""en la fecha"",
                ""dxScheduler-recurrenceRepeatCount"": ""ocurrencia(s)"",
                ""dxScheduler-allDay"": ""Todo el d\xeda"",
                ""dxScheduler-confirmRecurrenceEditMessage"": ""\xbfQuiere modificar solo esta cita o toda la serie?"",
                ""dxScheduler-confirmRecurrenceDeleteMessage"": ""\xbfQuiere eliminar solo esta cita o toda la serie?"",
                ");
            WriteLiteral(@"""dxScheduler-confirmRecurrenceEditSeries"": ""Modificar serie"",
                ""dxScheduler-confirmRecurrenceDeleteSeries"": ""Eliminar serie"",
                ""dxScheduler-confirmRecurrenceEditOccurrence"": ""Modificar cita"",
                ""dxScheduler-confirmRecurrenceDeleteOccurrence"": ""Eliminar cita"",
                ""dxScheduler-noTimezoneTitle"": ""Sin zona horaria"",
                ""dxScheduler-moreAppointments"": ""{0} m\xe1s"",
                ""dxCalendar-todayButtonText"": ""Hoy"",
                ""dxCalendar-ariaWidgetName"": ""Calendario"",
                ""dxColorView-ariaRed"": ""Rojo"",
                ""dxColorView-ariaGreen"": ""Verde"",
                ""dxColorView-ariaBlue"": ""Azul"",
                ""dxColorView-ariaAlpha"": ""Transparencia"",
                ""dxColorView-ariaHex"": ""C\xf3digo del color"",
                ""dxTagBox-selected"": ""{0} seleccionado"",
                ""dxTagBox-allSelected"": ""Todos seleccionados ({0})"",
                ""dxTagBox-moreSelected"": ""{0} m\xe1s"",
                """);
            WriteLiteral(@"vizExport-printingButtonText"": ""Imprimir"",
                ""vizExport-titleMenuText"": ""Exportar/Imprimir"",
                ""vizExport-exportButtonText"": ""Archivo {0}"",
                ""dxFilterBuilder-and"": ""Y"",
                ""dxFilterBuilder-or"": ""O"",
                ""dxFilterBuilder-notAnd"": ""NO Y"",
                ""dxFilterBuilder-notOr"": ""NO O"",
                ""dxFilterBuilder-addCondition"": ""A\xf1adir condici\xf3n"",
                ""dxFilterBuilder-addGroup"": ""A\xf1adir Grupo"",
                ""dxFilterBuilder-enterValueText"": ""<rellene con un valor>"",
                ""dxFilterBuilder-filterOperationEquals"": ""Igual"",
                ""dxFilterBuilder-filterOperationNotEquals"": ""Diferente"",
                ""dxFilterBuilder-filterOperationLess"": ""Menos que"",
                ""dxFilterBuilder-filterOperationLessOrEquals"": ""Menor o igual que"",
                ""dxFilterBuilder-filterOperationGreater"": ""M\xe1s grande que"",
                ""dxFilterBuilder-filterOperationGreaterOrEquals"": ""Mayor");
            WriteLiteral(@" o igual que"",
                ""dxFilterBuilder-filterOperationStartsWith"": ""Comienza con"",
                ""dxFilterBuilder-filterOperationContains"": ""Contiene"",
                ""dxFilterBuilder-filterOperationNotContains"": ""No contiene"",
                ""dxFilterBuilder-filterOperationEndsWith"": ""Termina con"",
                ""dxFilterBuilder-filterOperationIsBlank"": ""Vac\xedo"",
                ""dxFilterBuilder-filterOperationIsNotBlank"": ""No vac\xedo"",
                ""dxFilterBuilder-filterOperationBetween"": ""Entre"",
                ""dxFilterBuilder-filterOperationAnyOf"": ""Alguno de"",
                ""dxFilterBuilder-filterOperationNoneOf"": ""Ning\xfan de"",
                ""dxHtmlEditor-dialogColorCaption"": ""Cambiar el color de la fuente"",
                ""dxHtmlEditor-dialogBackgroundCaption"": ""Cambiar el color de fondo"",
                ""dxHtmlEditor-dialogLinkCaption"": ""A\xf1adir enlace"",
                ""dxHtmlEditor-dialogLinkUrlField"": ""URL"",
                ""dxHtmlEditor-dialogLinkText");
            WriteLiteral(@"Field"": ""Texto"",
                ""dxHtmlEditor-dialogLinkTargetField"": ""Abrir enlace en nueva ventana"",
                ""dxHtmlEditor-dialogImageCaption"": ""A\xf1adir imagen"",
                ""dxHtmlEditor-dialogImageUrlField"": ""URL"",
                ""dxHtmlEditor-dialogImageAltField"": ""Texto alternativo"",
                ""dxHtmlEditor-dialogImageWidthField"": ""Anchura (px)"",
                ""dxHtmlEditor-dialogImageHeightField"": ""Altura (px)"",
                ""dxHtmlEditor-heading"": ""Encabezamiento"",
                ""dxHtmlEditor-normalText"": ""Texto normal"",
                ""dxFileManager-errorNoAccess"": ""TODO!"",
                ""dxFileManager-errorDirectoryExistsFormat"": ""TODO!"",
                ""dxFileManager-errorFileExistsFormat"": ""TODO!"",
                ""dxFileManager-errorFileNotFoundFormat"": ""TODO!"",
                ""dxFileManager-errorDefault"": ""TODO!""
            }
        })
    });
</script>");
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
