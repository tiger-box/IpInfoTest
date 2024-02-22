using Microsoft.EntityFrameworkCore;

namespace IpInfoTest.Models
{
	public class IpHistoryContext : DbContext
	{
		public DbSet<IpHistory> IpInfos { get; set; }

		public IpHistoryContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
			var configuration = builder.Build();
			string? connectionString = configuration.GetConnectionString("DefaultConnection");

			if (connectionString != null)
			{
				optionsBuilder.UseMySql(connectionString,
					new MySqlServerVersion(new Version(8, 0, 34)));
			}

		}
	}
}
