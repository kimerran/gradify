using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Gradify.Web.Domain
{
    public class Grade : DomainEntity
    {
        [JsonProperty("subject"), Column("subject"), MaxLength(50)]
        [Required]
        public string Subject { get; set; }

        [JsonProperty("instructor"), Column("instructor"), MaxLength(50)]
        public string Instructor { get; set; }

        [JsonProperty("term"), Column("term"), MaxLength(20)]
        public string Term { get; set; }

        [JsonProperty("score"), Column("score"), MaxLength(10)]
        [Required]
        public string Score { get; set; }

        [JsonProperty("isPrivate"), Column("is_private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("passcode"), Column("passcode"), MaxLength(50)]
        public string Passcode { get; set; }

        [JsonProperty("created"), Column("created")]
        public DateTime Created { get; set; }

        [JsonProperty("shortUrl"), NotMapped]
        public string ShortUrl { get; set; }

        [NotMapped]
        public string CreatedShortDateString
        {
            get
            {
                return Created.ToString("D");
            }
        }
    }
}