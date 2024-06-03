using MongoDB.Driver;
using Microsoft.Extensions.Options;


namespace TodoApi.Models
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioService(IOptions<TodoDatabaseSettings> settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _usuarios = database.GetCollection<Usuario>(settings.Value.UsuariosCollectionName);
            
        }

        public async Task<List<Usuario>> GetAsync() =>
            await _usuarios.Find(usuario => true).ToListAsync();

        public async Task<Usuario?> GetAsync(string id) =>
            await _usuarios.Find<Usuario>(usuario => usuario.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Usuario usuario) =>
            await _usuarios.InsertOneAsync(usuario);

        public async Task UpdateAsync(string id, Usuario updatedUsuario) =>
            await _usuarios.ReplaceOneAsync(usuario => usuario.Id == id, updatedUsuario);

        public async Task RemoveAsync(string id) =>
            await _usuarios.DeleteOneAsync(usuario => usuario.Id == id);
    }

    public interface IUsuarioService
    {
        Task<List<Usuario>> GetAsync();
        Task<Usuario?> GetAsync(string id);
        Task CreateAsync(Usuario usuario);
        Task UpdateAsync(string id, Usuario updatedUsuario);
        Task RemoveAsync(string id);
    }
}
