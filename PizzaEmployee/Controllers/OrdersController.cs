using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaEmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PizzaEmployee.Controllers
{
    public class OrdersController : Controller
    {
        readonly string Baseurl = "https://localhost:44379/";


        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<OrderDetails> OrderInfo = new();
            using (HttpClient client = new())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("/P/GetAllOrderDetails");

                if(Res.IsSuccessStatusCode)
                {
                    var OrdResp = Res.Content.ReadAsStringAsync().Result;

                    OrderInfo = JsonConvert.DeserializeObject<List<OrderDetails>>(OrdResp);
                }
            }

            return View(OrderInfo);
        }
        public IActionResult GetOrder() => View();

        [Authorize]
        [HttpPost]
        public async Task <IActionResult> GetOrder(int id)
        {
            OrderDetails order = new();

            using (HttpClient httpClient = new())
            {
                httpClient.BaseAddress = new Uri(Baseurl);

                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await httpClient.GetAsync("/P/GetOrderDetails/" + id);

                if(response.IsSuccessStatusCode)
                {
                    var resp = response.Content.ReadAsStringAsync().Result;
                    order = JsonConvert.DeserializeObject<OrderDetails>(resp);
                }
                else
                {
                    ViewBag.StatusCode = response.StatusCode;
                }

            }
            return View(order);
        }
        public ViewResult OrderProgress() => View();
        /*[HttpPost]
        public async Task<IActionResult> OrderProgess(int? id)
        {
            Order o = new();
            OrderDetails order = new();
            using (HttpClient httpClient = new())
            {
                httpClient.BaseAddress = new Uri(Baseurl);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await httpClient.GetAsync("/Orders/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var resp = res.Content.ReadAsStringAsync().Result;
                    o = JsonConvert.DeserializeObject<Order>(resp);
                    Order no = new()
                    {
                        OrderId = o.OrderId,
                        OrderDate = o.OrderDate,
                        CustomerId = o.CustomerId,
                        Total = o.Total,
                        OrderStatus = "In Progress"
                    };
                    var v = new StringContent(JsonConvert.SerializeObject(no));
                    HttpResponseMessage put = await httpClient.PutAsync("/Orders/" + id, v);
                    if (put.IsSuccessStatusCode)
                    {
                        HttpResponseMessage response = await httpClient.GetAsync("/P/GetOrderDetails/" + id);

                        if (response.IsSuccessStatusCode)
                        {
                            var get = response.Content.ReadAsStringAsync().Result;
                            order = JsonConvert.DeserializeObject<OrderDetails>(get);
                            return View(order);
                        }
                        else
                        {
                            ViewBag.StatusCode = response.StatusCode;
                        }
                    }

                }
                else
                {
                    ViewBag.StatusCode = res.StatusCode;
                }
                return View();
            }
        }*/
    }
}
