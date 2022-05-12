using System.ComponentModel.DataAnnotations;
namespace API_REST_SQLSERVER.Entities
{
    public class usuario
    {
        [Key]
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? telefono { get; set; }

    }
}
