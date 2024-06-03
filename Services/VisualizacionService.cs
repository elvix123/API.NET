using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class VisualizacionService : IVisualizacionService
    {
        private readonly IMongoCollection<Visualizacion> _visualizaciones;
        private readonly IMongoCollection<Usuario> _usuarios;

        public VisualizacionService(IOptions<TodoDatabaseSettings> settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _visualizaciones = database.GetCollection<Visualizacion>(settings.Value.VisualizacionCollectionName);
            _usuarios = database.GetCollection<Usuario>("Usuarios");
        }

        public async Task<Usuario> GetUsuarioAsync(string idUsuario)
    {
        var filter = Builders<Usuario>.Filter.Eq(u => u.Id, idUsuario);
        return await _usuarios.Find(filter).FirstOrDefaultAsync();
    }

        public async Task<List<Visualizacion>> GetAsync() =>
            await _visualizaciones.Find(_ => true).ToListAsync();

        public async Task<Visualizacion?> GetAsync(string id) =>
            await _visualizaciones.Find(v => v.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Visualizacion visualizacion) =>
            await _visualizaciones.InsertOneAsync(visualizacion);

        public async Task UpdateAsync(string id, Visualizacion updatedVisualizacion) =>
            await _visualizaciones.ReplaceOneAsync(v => v.Id == id, updatedVisualizacion);

        public async Task RemoveAsync(string id) =>
            await _visualizaciones.DeleteOneAsync(v => v.Id == id);
    }

    public interface IVisualizacionService
    {
        Task<List<Visualizacion>> GetAsync();
        Task<Visualizacion?> GetAsync(string id);
        Task CreateAsync(Visualizacion visualizacion);
        Task UpdateAsync(string id, Visualizacion updatedVisualizacion);
        Task RemoveAsync(string id);
    }
}
