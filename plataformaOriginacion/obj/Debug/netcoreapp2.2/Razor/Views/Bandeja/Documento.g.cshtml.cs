#pragma checksum "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\Documento.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d085eb85405e3eba76a7ef8a641b05e3928a883b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bandeja_Documento), @"mvc.1.0.view", @"/Views/Bandeja/Documento.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Bandeja/Documento.cshtml", typeof(AspNetCore.Views_Bandeja_Documento))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d085eb85405e3eba76a7ef8a641b05e3928a883b", @"/Views/Bandeja/Documento.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13c4d1c73a75ca1b39d8fb86d41013f99381519a", @"/Views/_ViewImports.cshtml")]
    public class Views_Bandeja_Documento : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\Documento.cshtml"
  
    ViewData["Title"] = "Documento";

#line default
#line hidden
            BeginContext(47, 44, true);
            WriteLiteral("\r\n<div class=\"container\" style=\"margin:0\">\r\n");
            EndContext();
#line 7 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\Documento.cshtml"
     if (ViewBag.imagen != null)
    {

#line default
#line hidden
            BeginContext(132, 19, true);
            WriteLiteral("        <img alt=\"\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 151, "\"", 172, 1);
#line 9 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\Documento.cshtml"
WriteAttributeValue("", 157, ViewBag.imagen, 157, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(173, 37, true);
            WriteLiteral(" style=\"height:100%;width:100%;\" />\r\n");
            EndContext();
#line 10 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\Documento.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(234, 161, true);
            WriteLiteral("        <div style=\"background-color: lightcoral;color:white; padding:1em;\" align=\"center\"><strong>Atencion!!! La imagen no pudo ser encontrada.</strong></div>\r\n");
            EndContext();
#line 14 "C:\Users\gherr\Documents\Proyectos\plataformaOriginacion\plataformaOriginacion\Views\Bandeja\Documento.cshtml"
    }

#line default
#line hidden
            BeginContext(402, 10, true);
            WriteLiteral("</div>\r\n\r\n");
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
