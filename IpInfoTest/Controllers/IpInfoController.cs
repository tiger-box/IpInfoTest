using Microsoft.AspNetCore.Mvc;
using IpInfoTest.Models;

namespace IpInfoTest.Controllers
{
    [ApiController]
	[Route("ipinfo")]
	public class IpInfoController(IpApiClient ipApiClient) : Controller
	{
		private readonly IpApiClient _ipApiClient = ipApiClient;

		[HttpGet]
		public async Task<ActionResult> Get(string ip, CancellationToken ct)
		{
			try
			{
				using (var db = new IpHistoryContext())
				{
					var findIp = db.IpInfos.FirstOrDefault(IpInfo => IpInfo.Ip == ip);
					if (findIp == null)
					{
						var newIpHistory = new IpHistory()
						{
							Ip = ip,
							RequestCount = 1,
							LastRequestTime = DateTime.Now
						};

						db.IpInfos.Add(newIpHistory);
					}
                    else
                    {
						findIp.RequestCount++;
						findIp.LastRequestTime = DateTime.Now;
					}

					db.SaveChanges();
				}
				
				var ipApiResponse = await _ipApiClient.Get(ip, ct);
				var response = new
				{
					ip = ip,
					city = ipApiResponse?.city,
					region = ipApiResponse?.regionName,
					country = ipApiResponse?.country,
					loc = ipApiResponse?.lat.GetValueOrDefault() + " " + ipApiResponse?.lon.GetValueOrDefault(),
					org = ipApiResponse?.@as,
					postal = ipApiResponse?.zip,
					timezone = ipApiResponse?.timezone
				};

				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
	}
}
