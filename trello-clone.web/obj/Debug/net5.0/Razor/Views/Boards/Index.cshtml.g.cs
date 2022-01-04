#pragma checksum "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\Boards\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3db5b8e1cb155877ef3b4210ef2e18be582ec20b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Boards_Index), @"mvc.1.0.view", @"/Views/Boards/Index.cshtml")]
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
#nullable restore
#line 1 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\_ViewImports.cshtml"
using trello_clone.web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\_ViewImports.cshtml"
using trello_clone.web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3db5b8e1cb155877ef3b4210ef2e18be582ec20b", @"/Views/Boards/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26ce59f7b614185b800f4aab2577c28592c4b447", @"/Views/_ViewImports.cshtml")]
    public class Views_Boards_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<style>
  .board-list {
    display: flex;
    flex-wrap: wrap;
    justify-content: flex-start;
    list-style-type: none;
  }

  .board-item {
    margin: 0 2% 2% 0;
    padding: 0;
    transform: translate(0);
    width: 23.5%;
    height: 100px;
    background-color: #9ff09f;
    text-align: center;
    justify-content: center;
  }
  
  .org-boards {
    background-color: rgb(43, 43, 83);
  }
</style>
");
#nullable restore
#line 24 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\Boards\Index.cshtml"
 for(int i=0; i < ViewBag.Organizations.Count; i++) {

#line default
#line hidden
#nullable disable
            WriteLiteral("  <div class=\"org-boards\">\r\n  <div class=\"boards\">\r\n    <h3>");
#nullable restore
#line 27 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\Boards\Index.cshtml"
   Write(ViewBag.Organizations[i].displayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    <ul class=\"board-list\">\r\n");
#nullable restore
#line 29 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\Boards\Index.cshtml"
       for(int j=0; j < @ViewBag.AllBoards[i].Count; j++) {
        

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"board-item\">\r\n");
#nullable restore
#line 32 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\Boards\Index.cshtml"
            string nameBoard = ViewBag.AllBoards[i][j].name;

#line default
#line hidden
#nullable disable
            WriteLiteral("          ");
#nullable restore
#line 33 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\Boards\Index.cshtml"
     Write(Html.ActionLink(nameBoard, "read", new { id =  @ViewBag.AllBoards[i][j].id}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </li>   \r\n");
#nullable restore
#line 35 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\Boards\Index.cshtml"
      }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n  </div>\r\n</div>\r\n");
#nullable restore
#line 39 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\Boards\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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