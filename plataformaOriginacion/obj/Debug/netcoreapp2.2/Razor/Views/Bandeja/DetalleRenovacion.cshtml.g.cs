#pragma checksum "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64c2c815d823df16599d9ca7edd352426d8408da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bandeja_DetalleRenovacion), @"mvc.1.0.view", @"/Views/Bandeja/DetalleRenovacion.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Bandeja/DetalleRenovacion.cshtml", typeof(AspNetCore.Views_Bandeja_DetalleRenovacion))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64c2c815d823df16599d9ca7edd352426d8408da", @"/Views/Bandeja/DetalleRenovacion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13c4d1c73a75ca1b39d8fb86d41013f99381519a", @"/Views/_ViewImports.cshtml")]
    public class Views_Bandeja_DetalleRenovacion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
  
    ViewData["Title"] = "DetalleRenovacion";

#line default
#line hidden
#line 4 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
 if (ViewBag.error == null)
{

#line default
#line hidden
            BeginContext(85, 315, true);
            WriteLiteral(@"    <div class=""container"" style=""margin:1em;"">
        <div class=""col-md-12 row"" style=""background-color: #e5e5e5;padding:1em;border-radius: 25px;border-radius: 25px;opacity:.9;"">
            <div class=""col-md-4 col-md-offset-4""></div>
            <h1><label><strong>Detalle Renovacion</strong></label></h1>
");
            EndContext();
#line 10 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
             if (ViewBag.solicitud.status == 2)
            {

#line default
#line hidden
            BeginContext(464, 94, true);
            WriteLiteral("                <label class=\"badge badge-success\" style=\"height: 21px;\">DICTAMINADO</label>\r\n");
            EndContext();
#line 13 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
            }
            else if (ViewBag.solicitud.status == 3)
            {

#line default
#line hidden
            BeginContext(641, 91, true);
            WriteLiteral("                <label class=\"badge badge-danger\" style=\"height: 21px;\">RECHAZADO</label>\r\n");
            EndContext();
#line 17 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
            }
            else if (ViewBag.solicitud.status == 9)
            {

#line default
#line hidden
            BeginContext(815, 97, true);
            WriteLiteral("                <label class=\"badge badge-primary\" style=\"height: 21px;\">POR DICTAMINAR</label>\r\n");
            EndContext();
#line 21 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(960, 127, true);
            WriteLiteral("                <label id=\"_label\" class=\"badge badge-secondary\" style=\"height: 21px;\">POR AUTORIZAR CONSULTA DE BURÓ</label>\r\n");
            EndContext();
#line 25 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
            }

#line default
#line hidden
            BeginContext(1102, 683, true);
            WriteLiteral(@"        </div>
    </div>
    <div class=""container"" style=""margin-bottom:.5em;"" align=""center"">
        <div class=""col-md-12 row"" style=""background-color: #f5f5f5;padding:1em;border-radius: 25px;opacity:.9;"">
            <div class=""col-md-6"">
                <table class=""table table-sm"">
                    <col width=""40%"">
                    <col width=""60%"">
                    <tbody>
                        <tr>
                            <td><span class=""flaticon-man-user"" style=""position: relative;margin-left: -20px;color: lightgray;""></span><strong> NOMBRE:</strong></td>
                            <td id=""tdNombre"">
                                ");
            EndContext();
            BeginContext(1786, 24, false);
#line 38 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                           Write(ViewBag.solicitud.nombre);

#line default
#line hidden
            EndContext();
            BeginContext(1810, 315, true);
            WriteLiteral(@"
                            </td>
                        </tr>
                        <tr>
                            <td><span class=""flaticon-to-do-list"" style=""position: relative;margin-left: -20px;color: lightgray;""></span><strong> CLIENTE ID:</strong></td>
                            <td id=""tdCurp"">");
            EndContext();
            BeginContext(2126, 27, false);
#line 43 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                                       Write(ViewBag.solicitud.clienteID);

#line default
#line hidden
            EndContext();
            BeginContext(2153, 284, true);
            WriteLiteral(@"</td>
                        </tr>
                        <tr>
                            <td><span class=""flaticon-to-do-list"" style=""position: relative;margin-left: -20px;color: lightgray;""></span><strong> CREDITO ID:</strong></td>
                            <td id=""tdRfc"">");
            EndContext();
            BeginContext(2438, 27, false);
#line 47 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                                      Write(ViewBag.solicitud.creditoID);

#line default
#line hidden
            EndContext();
            BeginContext(2465, 346, true);
            WriteLiteral(@"</td>
                        </tr>
                        <tr>
                            <td><span class=""flaticon-dollar-symbol"" style=""position: relative;margin-left: -20px;color: lightgray;""></span><strong> IMPORTE:</strong></td>
                            <td id=""tdRfc""><label class=""badge badge-info"" style=""font-size:1em""><strong>");
            EndContext();
            BeginContext(2812, 63, false);
#line 51 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                                                                                                    Write(string.Format("{0:#,0.00}", ViewBag.solicitud.importeHistorico));

#line default
#line hidden
            EndContext();
            BeginContext(2875, 302, true);
            WriteLiteral(@"</strong></label></td>
                        </tr>
                        <tr>
                            <td><span class=""flaticon-dollar-symbol"" style=""position: relative;margin-left: -20px;color: lightgray;""></span><strong> CAPITAL:</strong></td>
                            <td id=""tdCurp"">");
            EndContext();
            BeginContext(3178, 54, false);
#line 55 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                                       Write(string.Format("{0:#,0.00}", ViewBag.solicitud.capital));

#line default
#line hidden
            EndContext();
            BeginContext(3232, 286, true);
            WriteLiteral(@"</td>
                        </tr>
                        <tr>
                            <td><span class=""flaticon-calendar"" style=""position: relative;margin-left: -20px;color: lightgray;""></span><strong> DÍAS DE ATRASO:</strong></td>
                            <td id=""tdRfc"">");
            EndContext();
            BeginContext(3519, 28, false);
#line 59 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                                      Write(ViewBag.solicitud.diasAtraso);

#line default
#line hidden
            EndContext();
            BeginContext(3547, 627, true);
            WriteLiteral(@"</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class=""col-md-6"">
                <table class=""table table-sm"">
                    <col width=""40%"">
                    <col width=""60%"">
                    <tbody>
                        <tr>
                            <td><span class=""flaticon-dollar-symbol"" style=""position: relative;margin-left: -20px;color: lightgray;""></span><strong> IMPORTE RENOVACIÓN:</strong></td>
                            <td id=""tdRfc""><label class=""badge badge-success"" style=""font-size:1em""><strong>");
            EndContext();
            BeginContext(4175, 54, false);
#line 71 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                                                                                                       Write(string.Format("{0:#,0.00}", ViewBag.solicitud.importe));

#line default
#line hidden
            EndContext();
            BeginContext(4229, 310, true);
            WriteLiteral(@"</strong></label></td>
                        </tr>
                        <tr>
                            <td><span class=""flaticon-to-do-list-1"" style=""position: relative;margin-left: -20px;color: lightgray;""></span><strong> TICKET CONFIASHOP:</strong></td>
                            <td id=""tdRfc"">");
            EndContext();
            BeginContext(4541, 76, false);
#line 75 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                                       Write(ViewBag.solicitud.ticket == "null" ? "Sin ticket" : ViewBag.solicitud.ticket);

#line default
#line hidden
            EndContext();
            BeginContext(4618, 195, true);
            WriteLiteral("</td>\r\n                        </tr>\r\n                    </tbody>\r\n                </table>\r\n                <div class=\"\" style=\"margin-top: 3em;\">\r\n                    <center id=\"botonera\">\r\n");
            EndContext();
#line 81 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                         if (@ViewBag.solicitud.status == 9)
                        {

#line default
#line hidden
            BeginContext(4902, 301, true);
            WriteLiteral(@"                            <a href=""#"" id=""montoDictamen"" class=""form_cambio btn btn-success"" onClick=""return false;"" data-toggle=""modal"" data-target=""#ModalDictamen"" style=""margin-top:1em;""><span class=""flaticon-correct-symbol"" style=""position: relative;margin-left: -20px;""></span> DICTAMINAR</a>
");
            EndContext();
            BeginContext(5205, 288, true);
            WriteLiteral(@"                            <a href=""#"" id=""razonRechazo"" class=""form_cambio btn btn-danger"" onClick=""return false;"" data-toggle=""modal"" data-target=""#ModalRechazo"" style=""margin-top:1em;""><span class=""flaticon-x-mark"" style=""position: relative;margin-left: -20px;""></span> RECHAZAR</a>
");
            EndContext();
#line 86 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                        }
                        else if (@ViewBag.solicitud.status == 2)
                        {

#line default
#line hidden
            BeginContext(5613, 201, true);
            WriteLiteral("                            <label class=\"badge badge-success\" style=\"font-size:1.1em\"><span class=\"flaticon-correct-symbol\" style=\"position: relative;margin-left: -20px;\"></span> DICTAMINADO</label>\r\n");
            EndContext();
#line 90 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                        }
                        else if (ViewBag.solicitud.status == 3)
                        {

#line default
#line hidden
            BeginContext(5933, 190, true);
            WriteLiteral("                            <label class=\"badge badge-danger\" style=\"font-size:1.1em\"><span class=\"flaticon-x-mark\" style=\"position: relative;margin-left: -20px;\"></span> RECHAZADO</label>\r\n");
            EndContext();
#line 94 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                        }

#line default
#line hidden
            BeginContext(6150, 163, true);
            WriteLiteral("                    </center>\r\n                    <center id=\"mensajeBotonera\"></center>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
            BeginContext(6315, 1207, true);
            WriteLiteral(@"    <!-- Modal DICTAMEN-->
    <div class=""modal fade"" id=""ModalDictamen"" role=""dialog"" data-keyboard=""false"" data-backdrop=""static"">
        <div class=""modal-dialog "" style=""border-radius: 25px;opacity:.9;"">

            <!-- Modal content-->
            <div class=""modal-content"">
                <div class=""modal-header"" style=""background-color: steelblue;"">
                    <label style=""margin-left: auto; color:white;""><Strong>DICTAMINAR SOLICITUD</Strong></label>
                    <button type=""button"" class=""close accionModal"" data-dismiss=""modal""><span class=""flaticon-x-mark"" style=""position: relative;margin-left: -20px;color:white;""></span></button>
                    <button type=""button"" class=""close cargandoModal"">-</button>
                </div>
                <div id=""form_dictamen"" class=""modal-body"">
                    <div class=""form-group"">
                        <label><strong>Importe Dictaminado:</strong></label>
                        <br />
                   ");
            WriteLiteral("     <div style=\"padding-left:3em;padding-right:3em;\">\r\n                            <input id=\"text_monto\" type=\"text\" class=\"form-control\" maxlength=\"10\" onkeypress=\'validate(event)\'");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 7522, "\"", 7556, 1);
#line 118 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
WriteAttributeValue("", 7530, ViewBag.solicitud.importe, 7530, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(7557, 690, true);
            WriteLiteral(@" style=""text-align:center;"" />
                        </div>
                    </div>
                    <div class=""form-group"" align=""center"">
                        <button id=""enviar_dictamen"" type=""button"" class=""btn btn-success accionModal""><span class=""flaticon-correct-symbol"" style=""position: relative;margin-left: -20px;""></span> CONFIRMAR</button>
                        <label class=""cargandoModal""><strong>DICTAMINANDO, POR FAVOR ESPERE ...</strong></label>
                    </div>
                </div>
                <div class=""modal-footer"" style=""background-color: steelblue;"">
                </div>
            </div>

        </div>
    </div>
");
            EndContext();
            BeginContext(8249, 1927, true);
            WriteLiteral(@"    <!-- Modal RECHAZO-->
    <div class=""modal fade"" id=""ModalRechazo"" role=""dialog"" data-keyboard=""false"" data-backdrop=""static"">
        <div class=""modal-dialog modal-lg"" style=""border-radius: 25px;opacity:.9;"">

            <!-- Modal content-->
            <div class=""modal-content"">
                <div class=""modal-header"" style=""background-color: steelblue;"">
                    <label style=""margin-left: auto; color:white;""><Strong>RECHAZAR SOLICITUD</Strong></label>
                    <button type=""button"" class=""close accionModal"" data-dismiss=""modal""><span class=""flaticon-x-mark"" style=""position: relative;margin-left: -20px;color:white;""></span></button>
                    <button type=""button"" class=""close cargandoModal"">-</button>
                </div>
                <div id=""form_dictamen"" class=""modal-body"">
                    <div class=""form-group"">
                        <label><strong>Motivo:</strong></label>
                        <br />
                        <div");
            WriteLiteral(@" style=""padding-left:2em;padding-right:2em;"">
                            <textarea id=""text_rechazo"" placeholder=""Escribe aquí de forma breve y clara el motivo del rechazo."" style=""width:100%;text-transform:uppercase"" rows=""3"" maxlength=""99""></textarea>
                        </div>
                    </div>
                    <div class=""form-group"" align=""center"">
                        <button id=""enviar_rechazo"" type=""button"" class=""btn btn-success accionModal""><span class=""flaticon-x-mark"" style=""position: relative;margin-left: -20px;""></span> RECHAZAR</button>
                        <label class=""cargandoModal""><strong>RECHAZANDO, POR FAVOR ESPERE ...</strong></label>
                    </div>
                </div>
                <div class=""modal-footer"" style=""background-color: steelblue;"">
                </div>
            </div>

        </div>
    </div>
");
            EndContext();
            BeginContext(10178, 1003, true);
            WriteLiteral(@"    <script>
        $("".form_cambio"").click(function () {
            $(""#label_doc"").html(""<i>"" + $(""#tipoDoc_"" + $(this).attr('tipo')).text() + ""</i >"");
            $(""#enviar_cambio"").attr(""oid"", $(this).attr(""id""));
            $(""#enviar_cambio"").attr(""tipo"", $(this).attr(""tipo""));
            $(""#enviar_cambio"").attr(""version"", $(this).attr(""version""));
            //console.log($(this).attr(""id""))
            $(""#text_cambio"").attr(""disabled"", false);
            $(""#enviar_cambio"").show();
            $("".accionModal"").show();
            $("".cargandoModal"").hide();
            $(""#text_cambio"").val("""");
            if ($(this).text() == ""PENDIENTE"") {
                $(""#text_cambio"").val($(this).attr(""text""));
                $(""#text_cambio"").attr(""disabled"", true);
                $(""#enviar_cambio"").hide();
            }
        });

    $(""#enviar_dictamen"").click(function (e){
        $(""#enviar_dictamen"").attr(""disabled"", true);
        var idDoc = """);
            EndContext();
            BeginContext(11182, 29, false);
#line 185 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                Write(ViewBag.solicitud.solicitudID);

#line default
#line hidden
            EndContext();
            BeginContext(11211, 27, true);
            WriteLiteral("\";\r\n        var idGrupo = \"");
            EndContext();
            BeginContext(11239, 25, false);
#line 186 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                  Write(ViewBag.solicitud.grupoID);

#line default
#line hidden
            EndContext();
            BeginContext(11264, 26, true);
            WriteLiteral("\";\r\n        var importe = ");
            EndContext();
            BeginContext(11291, 25, false);
#line 187 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                 Write(ViewBag.solicitud.importe);

#line default
#line hidden
            EndContext();
            BeginContext(11316, 2702, true);
            WriteLiteral(@";
        var monto = parseFloat($(""#text_monto"").val());
        console.log(importe);
        console.log(monto);
        if (Number.isNaN(monto) || monto <= 0 || monto % 500 > 0 || monto > importe || typeof monto == ""undefined"") {
            alert(""El importe dictaminado debe ser:\n\n- mayor a 0 (cero)\n- menor o igual al monto inicial solicitado ($"" + importe + "" MXN)\n- multiplo de 500 (ej. 500, 1000, 1500, ..., etc.)"");
            $(""#enviar_dictamen"").attr(""disabled"", false);
        } else {
            if (confirm(""Esta a punto de dictaminar esta solicitud con el importe de $""+monto+"" MXN.\n\n\n¿Desea continuar?"")) {
                var dictamen = {
                    idDocumento: idDoc,
                    monto: monto,
                    motivoRechazo: null,
                    status: 2,
                    grupoID: idGrupo
                };

                $.ajax({
                    type: ""POST"",
                    url: ""/Bandeja/DictaminarRenovacion"",
               ");
            WriteLiteral(@"     content: ""application/json; charset=utf-8"",
                    dataType: ""json"",
                    data: dictamen,
                    beforeSend: function (xhr) {
                        $(""#botonera"").hide();
                        $("".accionModal"").hide();
                        $("".cargandoModal"").show();
                    },
                    success: function (d) {
                        if (d.Success) {
                            $(""#mensajeBotonera"").html(""DICTAMINANDO SOLICITUD, POR FAVOR ESPERE ..."")
                            $('#ModalDictamen').modal('toggle');
                            location.reload();
                        } else {
                            alert(""Error en respuesta."");
                            $(""#botonera"").show();
                        }
                        $(""#enviar_dictamen"").attr(""disabled"", false);
                        $("".accionModal"").show();
                        $("".cargandoModal"").hide();
                   ");
            WriteLiteral(@" },
                    error: function (xhr, textStatus, errorThrown) {
                        alert('Error al realizar la acción!!');
                        $(""#botonera"").show();
                        $(""#enviar_dictamen"").attr(""disabled"", false);
                        $("".accionModal"").show();
                        $("".cargandoModal"").hide();
                    }
                });

            } else {
                $(""#enviar_dictamen"").attr(""disabled"", false);
            }
        }
    });

    $(""#enviar_rechazo"").click(function (e){
        $(""#enviar_rechazo"").attr(""disabled"", true);
        var idDoc = """);
            EndContext();
            BeginContext(14019, 29, false);
#line 245 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                Write(ViewBag.solicitud.solicitudID);

#line default
#line hidden
            EndContext();
            BeginContext(14048, 75, true);
            WriteLiteral("\";\r\n        var motivo = $(\"#text_rechazo\").val();\r\n        var idGrupo = \"");
            EndContext();
            BeginContext(14124, 25, false);
#line 247 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                  Write(ViewBag.solicitud.grupoID);

#line default
#line hidden
            EndContext();
            BeginContext(14149, 26, true);
            WriteLiteral("\";\r\n        var importe = ");
            EndContext();
            BeginContext(14176, 25, false);
#line 248 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                 Write(ViewBag.solicitud.importe);

#line default
#line hidden
            EndContext();
            BeginContext(14201, 2298, true);
            WriteLiteral(@";
        if (motivo.length <= 0 || typeof motivo == ""undefined"") {
            alert(""Es necesario escribir el motivo del rechazo, por favor se breve y claro"");
            $(""#enviar_rechazo"").attr(""disabled"", false);
        } else {
            if (confirm(""Esta a punto de rechazar esta solicitud.\n\n\n¿Desea continuar?"")) {
                var dictamen = {
                    idDocumento: idDoc,
                    monto: importe,
                    motivoRechazo: motivo.toUpperCase(),
                    status: 3,
                    grupoID: idGrupo
                };

                $.ajax({
                    type: ""POST"",
                    url: ""/Bandeja/DictaminarRenovacion"",
                    content: ""application/json; charset=utf-8"",
                    dataType: ""json"",
                    data: dictamen,
                    beforeSend: function (xhr) {
                        $(""#botonera"").hide();
                        $("".accionModal"").hide();
               ");
            WriteLiteral(@"         $("".cargandoModal"").show();
                    },
                    success: function (d) {
                        if (d.Success) {
                            $(""#mensajeBotonera"").html(""RECHAZANDO SOLICITUD, POR FAVOR ESPERE ..."")
                            $('#ModalRechazo').modal('toggle');
                            location.reload();
                        } else {
                            alert(""Error en respuesta."");
                            $(""#botonera"").show();
                        }
                        $(""#enviar_rechazo"").attr(""disabled"", false);
                        $("".accionModal"").show();
                        $("".cargandoModal"").hide();
                    },
                    error: function (xhr, textStatus, errorThrown) {
                        alert('Error al realizar la acción!!');
                        $(""#botonera"").show();
                        $(""#enviar_rechazo"").attr(""disabled"", false);
                        $("".accionM");
            WriteLiteral("odal\").show();\r\n                        $(\".cargandoModal\").hide();\r\n                    }\r\n                });\r\n\r\n            } else {\r\n                $(\"#enviar_rechazo\").attr(\"disabled\", false);\r\n            }\r\n        }\r\n    });\r\n    </script>\r\n");
            EndContext();
#line 301 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(16511, 102, true);
            WriteLiteral("    <div style=\"background-color: lightcoral;color:white; padding:1em;\" align=\"center\"><strong>Error: ");
            EndContext();
            BeginContext(16614, 13, false);
#line 304 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
                                                                                                 Write(ViewBag.error);

#line default
#line hidden
            EndContext();
            BeginContext(16627, 17, true);
            WriteLiteral("</strong></div>\r\n");
            EndContext();
#line 305 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\DetalleRenovacion.cshtml"
}

#line default
#line hidden
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
