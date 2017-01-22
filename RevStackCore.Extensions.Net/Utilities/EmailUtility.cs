using System;
using System.Text.RegularExpressions;
using System.Globalization;

namespace RevStackCore.Extensions.Net
{
	public static class EmailUtility
	{
		public static bool IsValidEmail(string email)
		{
			bool validDomain = true;
			if (String.IsNullOrEmpty(email))
				return false;

			// Use IdnMapping class to convert Unicode domain names. 
			try
			{
				email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
					RegexOptions.None, TimeSpan.FromMilliseconds(200));
			}
			catch (RegexMatchTimeoutException)
			{
				validDomain = false;
			}

			if (!validDomain)
				return false;

			// Return true if email is in valid e-mail format. 
			try
			{
				return Regex.IsMatch(email,
					@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
					@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
					RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
			}
			catch (RegexMatchTimeoutException)
			{
				return false;
			}
		}


		private static string DomainMapper(Match match)
		{
			// IdnMapping class with default property values.
			var idn = new IdnMapping();
			var domainName = match.Groups[2].Value;
			domainName = idn.GetAscii(domainName);
			return match.Groups[1].Value + domainName;
		}
	}
}
