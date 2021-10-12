using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TimeTracking.WebApp.Pages.Employee
{
    public class TimeLogModel : PageModel
    {
        [BindProperty]
        public EmployeeListModel EmployeeList { get; set; }

        private readonly IHttpClientFactory _clientFactory;
        public TimeLogModel(IHttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
        }

        public async Task OnGetAsync()
        {
            HttpClient client = this._clientFactory.CreateClient("TimeTrackingAPI");

            HttpResponseMessage httpResponse = await client.GetAsync("/api/EmployeeTimeLog");

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResult = await httpResponse.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<EmployeeListModel>(jsonResult);

                EmployeeList = response;
            }
        }

        public async Task<IActionResult> OnGetEditAsync(int id)
        {
            HttpClient client = this._clientFactory.CreateClient("TimeTrackingAPI");
            EmployeeTimeLogModel response = new EmployeeTimeLogModel();

            HttpResponseMessage httpResponse = await client.GetAsync($"/api/EmployeeTimeLog/{id}");

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResult = await httpResponse.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<EmployeeTimeLogModel>(jsonResult);
            }

            return Partial("_TimeLogModalPartial", response);
        }

        public async Task OnPostUpdateAsync(int id, EmployeeTimeLogModel timeLogModel)
        {
            HttpClient client = this._clientFactory.CreateClient("TimeTrackingAPI");

            timeLogModel.ID = id;
            var jsonSerialized = JsonSerializer.Serialize(timeLogModel);
            var httpContent = new StringContent(jsonSerialized, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await client.PutAsync("/api/EmployeeTimeLog", httpContent);

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResult = await httpResponse.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<EmployeeListModel>(jsonResult);

                EmployeeList = response;
            }
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            HttpClient client = this._clientFactory.CreateClient("TimeTrackingAPI");

            HttpResponseMessage httpResponse = await client.DeleteAsync($"/api/EmployeeTimeLog/{id}");

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResult = await httpResponse.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<EmployeeListModel>(jsonResult);

                EmployeeList = response;
            }
        }
    }

    public class EmployeeTimeLogModel
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime ClockInTime { get; set; }
        public DateTime? ClockOutTime { get; set; }
        public bool IsActive { get; set; }
    }

    public class EmployeeListModel
    {
        public List<EmployeeTimeLogModel> Employees { get; set; }
        public int CurrentPage { get; set; } = 0;
        public int TotalCount { get; set; } = 0;
    }
}
