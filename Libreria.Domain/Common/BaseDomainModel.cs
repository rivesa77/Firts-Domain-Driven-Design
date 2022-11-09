using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Libreria.Domain.Common
{
    public abstract class BaseDomainModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }

        [JsonIgnore]
        public string? CreatedBy { get; set; }

        [JsonIgnore]
        public DateTime? LastModifiedDate { get; set; }

        [JsonIgnore]
        public string? LastModifiedBy { get; set; }
    }
}