using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IpInfoTest.Models
{
	[Table("ip_history")]
	[Index(nameof(Ip), IsUnique = true)]
	public class IpHistory
	{
		[Key, Column("id")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Column("ip")]
		[Required]
		[MaxLength(15)]
		public string? Ip { get; set; }

		[Column("request_count")]
		[Required]
		public int RequestCount { get; set; }

		[Column("last_request_time")]
		[Required]
		public DateTime LastRequestTime { get; set; }
	}
}
