using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KokkunLms.Web.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using KokkunLms.Web.Models.Settings;
using KokkunLms.Web.Models.ApiResponses;

namespace KokkunLms.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApiSettings _apiSettings;
    public HomeController(ILogger<HomeController> logger, IOptions<ApiSettings> apiSettings)
    {
        _logger = logger;
        _apiSettings = apiSettings.Value;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(string usernameOrEmail, string password, bool rememberMe)
    {
        if (string.IsNullOrEmpty(usernameOrEmail) || string.IsNullOrEmpty(password))
        {
            ViewBag.Error = "Username/Email and Password are required.";
            return View("Index");
        }

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);


            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                usernameOrEmail = usernameOrEmail,
                password = password
            }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("auth/signin", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var resultJson = await response.Content.ReadAsStringAsync();

                // Deserialize the response structure
                var apiResponse = JsonConvert.DeserializeObject<SignInApiResponse>(resultJson);
                if (apiResponse != null && apiResponse.Success && apiResponse.Data != null)
                {
                    var token = apiResponse.Data.Token;
                    var refreshToken = apiResponse.Data.RefreshToken;

                    // Store tokens in session
                    HttpContext.Session.SetString("JWToken", token);
                    HttpContext.Session.SetString("RefreshToken", refreshToken);

                    // must redirect to page depend on role of user return RedirectToAction("Dashboard", "Home");
                    ViewBag.Error = token;
                    return View("Index");
                }
                else
                {
                    ViewBag.Error = "Invalid response from the server.";
                    return View("Index");
                }
            }
            else
            {
                string errorMessage = "Invalid username/email or password.";
                List<ApiErrorResponseDetails> errorDetails = new List<ApiErrorResponseDetails>();
                try
                {
                    var apiError = JsonConvert.DeserializeObject<ApiErrorResponse>(responseContent);
                    if (!string.IsNullOrEmpty(apiError?.Error))
                    {
                        errorMessage = apiError.Error;
                        errorDetails = apiError.Details;
                    }
                }
                catch
                {
                    // fallback to default error message
                }

                ViewBag.Error = errorMessage;
                ViewBag.ErrorDetails = errorDetails;
                return View("Index");
            }
        }
    }

}
