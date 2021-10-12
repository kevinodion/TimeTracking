using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TimeTracking.WebApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public LoginModel(IHttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
        }

        [BindProperty]
        public Credential Credential { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "Login";
        }

        public async Task<IActionResult> OnPost()
        {
            ViewData["Message"] = string.Empty;

            if (ModelState.IsValid)
            {
                HttpClient client = this._clientFactory.CreateClient("TimeTrackingAPI");

                StringContent credentials = new StringContent(
                    JsonSerializer.Serialize(Credential),
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage httpResponse = await client.PostAsync("/api/Login", credentials);

                if(httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResult = await httpResponse.Content.ReadAsStringAsync();
                    var response = JsonSerializer.Deserialize<AuthenticateResponse>(jsonResult);

                    var claims = new List<Claim>
                {
                    new Claim("AccessToken", response.Token),
                    new Claim(ClaimTypes.Name, response.EmployeeName)
                };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    return RedirectToPage("/Index");
                }
                else
                {
                    ViewData["Message"] = "Incorrect Username or Password!!!";

                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }
    }

    public class Credential
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class AuthenticateResponse
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public string Token { get; set; }
    }
}