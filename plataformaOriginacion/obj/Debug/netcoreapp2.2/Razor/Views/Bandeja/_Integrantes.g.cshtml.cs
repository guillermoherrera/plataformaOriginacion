#pragma checksum "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb50f2f679999ef0572234a149003b47ab3dd72a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bandeja__Integrantes), @"mvc.1.0.view", @"/Views/Bandeja/_Integrantes.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Bandeja/_Integrantes.cshtml", typeof(AspNetCore.Views_Bandeja__Integrantes))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb50f2f679999ef0572234a149003b47ab3dd72a", @"/Views/Bandeja/_Integrantes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13c4d1c73a75ca1b39d8fb86d41013f99381519a", @"/Views/_ViewImports.cshtml")]
    public class Views_Bandeja__Integrantes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(120, 282, true);
            WriteLiteral(@"
<table class=""table table-striped table-sm"">
    <thead>
        <tr>
            <th width=""15%"">Status</th>
            <th width=""50%"">Nombre</th>
            <th width=""15%"">Importe</th>
            <th width=""10%"">Acción</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 14 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
         foreach (Solicitud solicitud in ViewBag.solicitudes)
        {

#line default
#line hidden
            BeginContext(476, 40, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n");
            EndContext();
#line 18 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
                     switch (solicitud.status)
                    {
                        case 2:

#line default
#line hidden
            BeginContext(620, 79, true);
            WriteLiteral("                            <span class=\'badge badge-success\'>APROBADO</span>\r\n");
            EndContext();
#line 22 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
                            break;
                        case 3:

#line default
#line hidden
            BeginContext(768, 78, true);
            WriteLiteral("                            <span class=\'badge badge-danger\'>DENEGADO</span>\r\n");
            EndContext();
#line 25 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
                            break;
                        case 6:

#line default
#line hidden
            BeginContext(915, 79, true);
            WriteLiteral("                            <span class=\'badge badge-warning\'>REVISIÓN</span>\r\n");
            EndContext();
#line 28 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
                            break;
                        case 7:

#line default
#line hidden
            BeginContext(1063, 96, true);
            WriteLiteral("                            <span class=\'badge badge-secondary\'>EN ESPERA DE C. DE BURO</span>\r\n");
            EndContext();
#line 31 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
                            break;
                        case 8:

#line default
#line hidden
            BeginContext(1228, 97, true);
            WriteLiteral("                            <span class=\'badge badge-secondary\'>EN PROCESO DE C. DE BURO</span>\r\n");
            EndContext();
#line 34 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
                            break;
                        case 9:

#line default
#line hidden
            BeginContext(1394, 85, true);
            WriteLiteral("                            <span class=\'badge badge-primary\'>POR DICTAMINAR</span>\r\n");
            EndContext();
#line 37 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
                            break;
                        case 10:

#line default
#line hidden
            BeginContext(1549, 89, true);
            WriteLiteral("                            <span class=\'badge badge-danger\'>ERROR EN C. DE BURO</span>\r\n");
            EndContext();
#line 40 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
                            break;
                        default:

#line default
#line hidden
            BeginContext(1708, 92, true);
            WriteLiteral("                            <span class=\'badge badge-info\'>POR AUTORIZAR C. DE BURÓ</span>\r\n");
            EndContext();
#line 43 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
                            break;
                    }

#line default
#line hidden
            BeginContext(1859, 130, true);
            WriteLiteral("                </td>\r\n                <td><span class=\"flaticon-man-user\" style=\"position: relative;margin-left: -20px;\"></span> ");
            EndContext();
            BeginContext(1991, 141, false);
#line 46 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
                                                                                                       Write(solicitud.persona.nombre + " " + solicitud.persona.nombreSegundo + " " + solicitud.persona.apellido + " " + solicitud.persona.apellidoSegundo);

#line default
#line hidden
            EndContext();
            BeginContext(2133, 69, true);
            WriteLiteral("</td>\r\n                <td align=\"right\" style=\"padding-right: 4em;\">");
            EndContext();
            BeginContext(2203, 46, false);
#line 47 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
                                                         Write(string.Format("{0:#,0.00}", solicitud.importe));

#line default
#line hidden
            EndContext();
            BeginContext(2249, 37, true);
            WriteLiteral("</td>\r\n                <td><center><a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 2286, "\'", 2337, 2);
            WriteAttributeValue("", 2293, "/Bandeja/Detalle/?_ID=", 2293, 22, true);
#line 48 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
WriteAttributeValue("", 2315, solicitud.solicitudID, 2315, 22, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2338, 59, true);
            WriteLiteral(" target=\'_blank\'>VER</a></center></td>\r\n            </tr>\r\n");
            EndContext();
#line 50 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
        }

#line default
#line hidden
            BeginContext(2408, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
#line 53 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
 if (ViewBag.grupo.integrantes > ViewBag.solicitudes.Count)
{

#line default
#line hidden
            BeginContext(2496, 371, true);
            WriteLiteral(@"    <label class=""badge badge-danger"">
        *No se han sincronizado todos los integrantes del grupo.<br />
        *Es posible aprobar o denegar a los integrantes actuales mas no es posible dictaminar el grupo hasta que este completo.<br /><br />
        Por favor espere un momento o póngase en contacto con el asesor para confirmar la información.
    </label>
");
            EndContext();
#line 60 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
}
else
{
    

#line default
#line hidden
#line 63 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
     if (ViewBag.dictaminable == true && ViewBag.dictamen == null)
    {

#line default
#line hidden
            BeginContext(2954, 48, true);
            WriteLiteral("        <center id=\"botonera\">\r\n\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3002, "\"", 3074, 3);
            WriteAttributeValue("", 3009, "/Bandeja/grupoDictamen/?_ID=", 3009, 28, true);
#line 67 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
WriteAttributeValue("", 3037, ViewBag.solicitudes[0].grupoID, 3037, 31, false);

#line default
#line hidden
            WriteAttributeValue("", 3068, "&aut=1", 3068, 6, true);
            EndWriteAttribute();
            BeginContext(3075, 164, true);
            WriteLiteral(" class=\"btn btn-success btn_APRGPO\"><span class=\"flaticon-correct-symbol\" style=\"position: relative;margin-left: -20px;\"></span> APROBAR GRUPO</a>\r\n\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3239, "\"", 3311, 3);
            WriteAttributeValue("", 3246, "/Bandeja/grupoDictamen/?_ID=", 3246, 28, true);
#line 69 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
WriteAttributeValue("", 3274, ViewBag.solicitudes[0].grupoID, 3274, 31, false);

#line default
#line hidden
            WriteAttributeValue("", 3305, "&aut=0", 3305, 6, true);
            EndWriteAttribute();
            BeginContext(3312, 160, true);
            WriteLiteral(" class=\"btn btn-danger btn_DENGPO\"><span class=\"flaticon-x-mark\" style=\"position: relative;margin-left: -20px;\"></span> DENEGAR GRUPO</a>\r\n\r\n        </center>\r\n");
            EndContext();
#line 72 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
    }
    else if (ViewBag.dictamen != null)
    {

#line default
#line hidden
            BeginContext(3526, 68, true);
            WriteLiteral("        <label class=\"badge badge-info\">*Grupo Dictaminado</label>\r\n");
            EndContext();
#line 76 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(3618, 124, true);
            WriteLiteral("        <label class=\"badge badge-info\">*Es necesario aprobar o denegar a cada intengrate para dictaminar el grupo</label>\r\n");
            EndContext();
#line 80 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
    }

#line default
#line hidden
#line 80 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\_Integrantes.cshtml"
     
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
