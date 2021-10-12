#pragma checksum "C:\Users\ps082469\Documents\Git\Exam\WebApp\TimeTracking\TimeTracking.WebApp\Pages\Employee\TimeLog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e4fc461f4f60e6c976f08443c54ef4c494f3152a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TimeTracking.WebApp.Pages.Employee.Pages_Employee_TimeLog), @"mvc.1.0.razor-page", @"/Pages/Employee/TimeLog.cshtml")]
namespace TimeTracking.WebApp.Pages.Employee
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
#line 1 "C:\Users\ps082469\Documents\Git\Exam\WebApp\TimeTracking\TimeTracking.WebApp\Pages\_ViewImports.cshtml"
using TimeTracking.WebApp;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4fc461f4f60e6c976f08443c54ef4c494f3152a", @"/Pages/Employee/TimeLog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4637bb0b1ad600629a6683235a9da29a33089dac", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Employee_TimeLog : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\ps082469\Documents\Git\Exam\WebApp\TimeTracking\TimeTracking.WebApp\Pages\Employee\TimeLog.cshtml"
  
    //User.Claims.SingleOrDefault(w => w.Type == "AccessToken").Value

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""card"">
    <h5 class=""card-header"">Employee Time Log</h5>
    <div class=""card-body"">
        <table class=""table table-hover table-bordered"">
            <thead>
                <tr>
                    <th>#</th>
                    <th>Employee Name</th>
                    <th>Clock-in Time</th>
                    <th>Clock-out Time</th>
                    <th>Active</th>
                    <th></th>
                </tr>
            </thead>
");
#nullable restore
#line 21 "C:\Users\ps082469\Documents\Git\Exam\WebApp\TimeTracking\TimeTracking.WebApp\Pages\Employee\TimeLog.cshtml"
             if (Model.EmployeeList != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tbody>\r\n");
#nullable restore
#line 24 "C:\Users\ps082469\Documents\Git\Exam\WebApp\TimeTracking\TimeTracking.WebApp\Pages\Employee\TimeLog.cshtml"
                     foreach (var employee in Model.EmployeeList.Employees)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 27 "C:\Users\ps082469\Documents\Git\Exam\WebApp\TimeTracking\TimeTracking.WebApp\Pages\Employee\TimeLog.cshtml"
                            Write(Model.EmployeeList.Employees.IndexOf(employee) + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 28 "C:\Users\ps082469\Documents\Git\Exam\WebApp\TimeTracking\TimeTracking.WebApp\Pages\Employee\TimeLog.cshtml"
                           Write(employee.EmployeeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 29 "C:\Users\ps082469\Documents\Git\Exam\WebApp\TimeTracking\TimeTracking.WebApp\Pages\Employee\TimeLog.cshtml"
                           Write(employee.ClockInTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 30 "C:\Users\ps082469\Documents\Git\Exam\WebApp\TimeTracking\TimeTracking.WebApp\Pages\Employee\TimeLog.cshtml"
                           Write(employee.ClockOutTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 31 "C:\Users\ps082469\Documents\Git\Exam\WebApp\TimeTracking\TimeTracking.WebApp\Pages\Employee\TimeLog.cshtml"
                           Write(employee.IsActive);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1238, "\"", 1299, 3);
            WriteAttributeValue("", 1248, "editTimeLog(\'?handler=Edit&id=", 1248, 30, true);
#nullable restore
#line 33 "C:\Users\ps082469\Documents\Git\Exam\WebApp\TimeTracking\TimeTracking.WebApp\Pages\Employee\TimeLog.cshtml"
WriteAttributeValue("", 1278, employee.ID, 1278, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1290, "\',\'Edit\')", 1290, 9, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info text-white\">Edit</a>\r\n                                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1377, "\"", 1435, 3);
            WriteAttributeValue("", 1387, "deleteTimeLog(\'?handler=Delete&id=", 1387, 34, true);
#nullable restore
#line 34 "C:\Users\ps082469\Documents\Git\Exam\WebApp\TimeTracking\TimeTracking.WebApp\Pages\Employee\TimeLog.cshtml"
WriteAttributeValue("", 1421, employee.ID, 1421, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1433, "\')", 1433, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info text-white\">Delete</a>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 37 "C:\Users\ps082469\Documents\Git\Exam\WebApp\TimeTracking\TimeTracking.WebApp\Pages\Employee\TimeLog.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n");
#nullable restore
#line 39 "C:\Users\ps082469\Documents\Git\Exam\WebApp\TimeTracking\TimeTracking.WebApp\Pages\Employee\TimeLog.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </table>
    </div>
</div>

<div id=""modalContainer""></div>

<script>
    $(document).ready(function () {
        var modalContainer = $('#modalContainer');

        editTimeLog = (url, title) => {
            try {
                $.ajax({
                    type: 'GET',
                    url: url,
                    success: function (data) {
                        modalContainer.html(data);
                        $('#editEmployeeTimeLog').modal('show');
                    },
                    error: function (err) {
                        console.log(err)
                    }
                });
                return false;
            }
            catch (ex) {
                console.log(ex)
            }
        }

        updateTimeLog = form => {
            try {
                $.ajax({
                    type: 'POST',
                    url: form.action,
                    data: new FormData(form),
                    contentType: false,
 ");
            WriteLiteral(@"                   processData: false,
                    success: function (res) {
                        $('#editEmployeeTimeLog').modal('hide');
                        modalContainer.html('');
                    },
                    error: function (err) {
                        console.log(err)
                    }
                })
            }
            catch (ex) {
                console.log(ex)
            }
        }

        deleteTimeLog = (url) => {
            try {
                $.ajax({
                    type: 'GET',
                    url: url,
                    processData: false,
                    success: function (data) {
                    },
                    error: function (err) {
                        console.log(err)
                    }
                });
            }
            catch (ex) {
                console.log(ex)
            }
        }
    });
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TimeTracking.WebApp.Pages.Employee.TimeLogModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TimeTracking.WebApp.Pages.Employee.TimeLogModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TimeTracking.WebApp.Pages.Employee.TimeLogModel>)PageContext?.ViewData;
        public TimeTracking.WebApp.Pages.Employee.TimeLogModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591