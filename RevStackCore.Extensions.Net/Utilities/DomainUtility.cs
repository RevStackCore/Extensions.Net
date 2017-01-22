using System;
using System.Globalization;
namespace RevStackCore.Extensions.Net
{
	public static class DomainUtility
	{
		public static bool IsValidDomain(string domain)
		{
			domain = GetAsciiDomain(domain);
			if (string.IsNullOrEmpty(domain))
				return false;
			else return true;
		}

		public static string GetAsciiDomain(string domain)
		{
			if (string.IsNullOrEmpty(domain))
				return null;
			
			var idn = new IdnMapping();
			try
			{
				domain = idn.GetAscii(domain);
				return domain;
			}
			catch (ArgumentException)
			{
				return null;
			}
		}

	}
}
