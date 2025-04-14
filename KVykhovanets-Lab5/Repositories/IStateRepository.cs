using KVykhovanets_Lab5.Models.TableModels;

namespace KVykhovanets_Lab5.Repositories
{
    public interface IStateRepository
    {
        Task<IEnumerable<States>> RetrieveAllAsync();
        Task<States?> RetrieveAsync(int id);
        Task<States?> CreateAsync(States state);
        Task<States?> UpdateAsync(int id, States state);
        Task<bool?> DeleteAsync(int id);
    }
}
