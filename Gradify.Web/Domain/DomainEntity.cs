using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Gradify.Web.Domain
{
    public class DomainEntity
    {
        [JsonProperty("id"), Column("id")]
        public int Id { get; set; }
    }
}