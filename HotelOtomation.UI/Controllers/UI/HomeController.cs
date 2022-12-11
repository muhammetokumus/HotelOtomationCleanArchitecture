using HotelOtomation.Domain.Entities;
using HotelOtomation.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;

namespace HotelOtomation.UI.Controllers.UI
{
    public class HomeController : Controller
    {
        HttpClient _httpClient;
        HttpResponseMessage _responseMessage;
        public HomeController()
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

        public async Task<IActionResult> Hotels()
        {
            _responseMessage = await _httpClient.GetAsync("https://localhost:7089/api/Hotels");
            var jsonString = await _responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Hotel>>(jsonString);
            foreach (var item in values)
            {
                _responseMessage = await _httpClient.GetAsync("https://localhost:7089/api/Cities/" + item.CityId );
                jsonString = await _responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<City>(jsonString);
                item.City = value;
            }
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> Hotels(string city)
        {
            List<Hotel> hotels= new();
            _responseMessage = await _httpClient.GetAsync("https://localhost:7089/api/Hotels");
            var jsonString = await _responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Hotel>>(jsonString);
            foreach (var item in values)
            {
                _responseMessage = await _httpClient.GetAsync("https://localhost:7089/api/Cities/" + item.CityId);
                jsonString = await _responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<City>(jsonString);
                item.City = value;
                if (item.City.Name == city)
                    hotels.Add(item);
            }
            return View(hotels);
        }

        public async Task<IActionResult> Detail(int id)
        {
            _responseMessage = await _httpClient.GetAsync("https://localhost:7089/api/Hotels/" + id);
            var jsonString = await _responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<Hotel>(jsonString);
            return View(value);
        }
    }
}