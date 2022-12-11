using HotelOtomation.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace HotelOtomation.UI.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        HttpClient _httpClient;
        HttpResponseMessage _responseMessage;
        public CityController()
        {
            _httpClient = new HttpClient();
        }
        public async Task<IActionResult> Index()
        {
            _responseMessage = await _httpClient.GetAsync("https://localhost:7089/api/Cities");
            var jsonString = await _responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<City>>(jsonString);
            return View(values);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(City city)
        {
            var jsonObject = JsonConvert.SerializeObject(city);
            var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            _responseMessage = await _httpClient.PostAsync("https://localhost:7089/api/Cities", stringContent);
            if (_responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            _responseMessage = await _httpClient.GetAsync("https://localhost:7089/api/Cities/" + id);
            if (_responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await _responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<City>(jsonString);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(City city)
        {
            var jsonObject = JsonConvert.SerializeObject(city);
            var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            _responseMessage = await _httpClient.PutAsync("https://localhost:7089/api/Cities", stringContent);
            if (_responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            _responseMessage = await _httpClient.DeleteAsync("https://localhost:7089/api/Cities?id=" + id);
            if (_responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return NotFound();
        }
    }
}
