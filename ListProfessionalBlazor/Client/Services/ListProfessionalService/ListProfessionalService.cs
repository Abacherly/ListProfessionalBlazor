using ListProfessionalBlazor.Client.Pages;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace ListProfessionalBlazor.Client.Services.ListProfessionalService
{
    public class ListProfessionalService : IListProfessionalService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ListProfessionalService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<ListProfessional> Professionals { get; set; } = new List<ListProfessional>();
        public List<Work> Works { get; set; } = new List<Work>();

        public async Task CreateProfessional(ListProfessional professional)
        {
            var result = await _http.PostAsJsonAsync("api/listprofessional", professional);
            await SetProfessionals(result);
        }

        private async Task SetProfessionals(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<ListProfessional>>();
            Professionals = response;
            _navigationManager.NavigateTo("listprofessionals");
        }

        public async Task DeleteProfessional(int id)
        {
            var result = await _http.DeleteAsync($"api/listprofessional/{id}");
            await SetProfessionals(result);
        }

        public async Task GetListProfessionals()
        {
            var result = await _http.GetFromJsonAsync<List<ListProfessional>>("api/listprofessional");
            if (result != null)
            {
                Professionals = result;
            }
        }

        public async Task<ListProfessional> GetSingleProfessional(int id)
        {
            var result = await _http.GetFromJsonAsync<ListProfessional>($"api/listprofessional/{id}");
                 if (result != null)
                   return result;
            throw new Exception(" Desculpe, profissional não encontrado.");
                        
        }

                
        

        public async Task GetWorks()
        {
            var result = await _http.GetFromJsonAsync<List<Work>>("api/listprofessional/works");
            if (result != null)
                Works = result;

        }

        public async Task UpdateProfessional(ListProfessional professional)
        {
            var result = await _http.PutAsJsonAsync($"api/listprofessional/{professional.Id}", professional);
            await SetProfessionals(result);
        }
    }
}
