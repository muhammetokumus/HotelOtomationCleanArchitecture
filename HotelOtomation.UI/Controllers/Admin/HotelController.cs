using HotelOtomation.Domain.Entities;
using HotelOtomation.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace HotelOtomation.UI.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class HotelController : Controller
    {
        HttpClient _httpClient;
        HttpResponseMessage _responseMessage;
        public HotelController()
        {
            _httpClient = new HttpClient();
        }
        public async Task<IActionResult> Index()
        {
            _responseMessage = await _httpClient.GetAsync("https://localhost:7089/api/Hotels");
            var jsonString = await _responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Hotel>>(jsonString);
            return View(values);
        }

        public async Task<IActionResult> Add(HotelViewModel model)
        {
            _responseMessage = await _httpClient.GetAsync("https://localhost:7089/api/Cities");
            var jsonString = await _responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<City>>(jsonString);
            model.Cities = values;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Hotel hotel)
        {
            var jsonObject = JsonConvert.SerializeObject(hotel);
            var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            _responseMessage = await _httpClient.PostAsync("https://localhost:7089/api/Hotels", stringContent);
            if (_responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> Edit(HotelViewModel model,int id)
        {
            model = new();
            _responseMessage = await _httpClient.GetAsync("https://localhost:7089/api/hotels/" + id);
            if (_responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await _responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Hotel>(jsonString);
                model.Hotel = value;
                _responseMessage = await _httpClient.GetAsync("https://localhost:7089/api/Cities");
                jsonString = await _responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<City>>(jsonString);
                model.Cities = values;
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,HotelViewModel model)
        {
            model.Hotel.Id = id;
            var jsonObject = JsonConvert.SerializeObject(model.Hotel);
            var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            _responseMessage = await _httpClient.PutAsync("https://localhost:7089/api/hotels", stringContent);
            if (_responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            _responseMessage = await _httpClient.DeleteAsync("https://localhost:7089/api/hotels?id=" + id);
            if (_responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return NotFound();
        }
    }
}
