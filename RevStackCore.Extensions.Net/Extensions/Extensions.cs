namespace RevStackCore.Extensions.Net
{
	public static partial class Extensions
	{
		public static bool ToIsValidEmail(this string source)
		{
			return EmailUtility.IsValidEmail(source);
		}

		public static bool ToIsValidDomain(this string source)
		{
			return DomainUtility.IsValidDomain(source);
		}

		public static string ToAsciiDomain(this string source)
		{
			return DomainUtility.GetAsciiDomain(source);
		}
	}
}
