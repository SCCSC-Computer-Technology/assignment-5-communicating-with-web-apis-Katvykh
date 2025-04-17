using Microsoft.AspNetCore.Mvc;
using KVykhovanets_Lab5_MVC.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace KVykhovanets_Lab5_MVC.Controllers
{

    public class StateController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public StateController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = _clientFactory.CreateClient("StateAPI");

            HttpResponseMessage response = await client.GetAsync("api/state");

            if (response.IsSuccessStatusCode)
            {
                var states = await response.Content.ReadFromJsonAsync<IEnumerable<States>>();
                return View(states);
            }

            return View(new List<States>());
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: State/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(States state)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _clientFactory.CreateClient("StateAPI");
                var response = await client.PostAsJsonAsync("api/state", state);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));  
                }
            }

            return View(state);  
        }

        // GET: State/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpClient client = _clientFactory.CreateClient("StateAPI");
            var response = await client.GetAsync($"api/state/{id}");

            if (response.IsSuccessStatusCode)
            {
                var state = await response.Content.ReadFromJsonAsync<States>();
                if (state == null)
                {
                    return NotFound();
                }

                return View(state);
            }

            return NotFound();
        }

        // GET: State/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpClient client = _clientFactory.CreateClient("StateAPI");
            var response = await client.GetAsync($"api/state/{id}");

            if (response.IsSuccessStatusCode)
            {
                var state = await response.Content.ReadFromJsonAsync<States>();
                if (state == null)
                {
                    return NotFound();
                }

                return View(state);
            }

            return NotFound();
        }

        // POST: State/Edit/5
        //[HttpPost("State/edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, States updatedState)
        {
            if (id != updatedState.StateID)
            //if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                HttpClient client = _clientFactory.CreateClient("StateAPI");
                
                var response = await client.PutAsJsonAsync($"api/state/{id}", updatedState);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index)); 
                }

                
            }
            
            return View(updatedState); // If validation fails, return to the Edit view
        }

        // GET: State/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpClient client = _clientFactory.CreateClient("StateAPI");
            var response = await client.GetAsync($"api/state/{id}");

            if (response.IsSuccessStatusCode)
            {
                var state = await response.Content.ReadFromJsonAsync<States>();
                if (state == null)
                {
                    return NotFound();
                }

                return View(state);
            }

            return NotFound();
        }

        // POST: State/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpClient client = _clientFactory.CreateClient("StateAPI");
            var response = await client.DeleteAsync($"api/state/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect back to the index page after deletion
            }

            return NotFound(); // If deletion fails, return a "Not Found" view
        }


    }
}
