
namespace ListProfessionalBlazor.Client.Services.ListProfessionalService
{
    public interface IListProfessionalService
    {
        List<ListProfessional> Professionals { get; set; }
        List<Work> Works { get; set; }
        Task GetWorks();
        Task GetListProfessionals();
        Task<ListProfessional>GetSingleProfessional(int id);
        Task CreateProfessional(ListProfessional professional);
        Task UpdateProfessional(ListProfessional professional);
        Task DeleteProfessional(int id);
    }
}
