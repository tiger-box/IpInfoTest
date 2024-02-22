namespace IpInfoTest.Models
{
	public class IpApiResponse
	{
		public string? status { get; set; }
		public string? query { get; set; }
		public string? city { get; set; }
		public string? regionName { get; set; }
		public string? country { get; set; }
		public double? lat { get; set; }
		public double? lon { get; set; }
		public string? @as { get; set; }
		public string? zip { get; set; }
		public string? timezone { get; set; }
	}
}
