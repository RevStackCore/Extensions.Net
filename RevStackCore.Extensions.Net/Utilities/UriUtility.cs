using System;
using System.Net;

namespace RevStackCore.Extensions.Net
{
	public class UriUtility
	{
		private HttpWebRequest _request;
		private readonly string SCHEME_DELIMITER = "://";
		public UriUtility(HttpWebRequest request)
		{
			_request = request;
		}

		public string Host
		{
			get
			{
				Uri uri = new Uri(_request.RequestUri.AbsoluteUri);
				string result = uri.Scheme + SCHEME_DELIMITER + uri.Host;
				if (uri.Port == 80) return result;
				else return result += ":" + uri.Port;
			}
		}

		public string CanonicalUrl
		{
			get
			{
				string url = Host;
				url += Path;
				return url;
			}
		}

		public string Path
		{
			get
			{
				return _request.RequestUri.AbsolutePath;
			}
		}

		public string LocalPath
		{
			get
			{
				return _request.RequestUri.LocalPath;
			}
		}

		public int Port
		{
			get
			{
				return _request.RequestUri.Port;
			}
		}

		public bool IsDefaultPort
		{
			get
			{
				return _request.RequestUri.IsDefaultPort;
			}
		}

		public string Query
		{
			get
			{
				return _request.RequestUri.Query;
			}
		}

		public string Domain
		{
			get
			{
				return _request.RequestUri.Authority;
			}
		}

		public string Protocol
		{
			get
			{
				return _request.RequestUri.Scheme;
			}
		}

		public bool IsAbsoluteUri
		{
			get
			{
				return _request.RequestUri.IsAbsoluteUri;
			}
		}

		public string PathAndQuery
		{
			get
			{
				return _request.RequestUri.PathAndQuery;
			}
		}

		public string SchemeDelimiter
		{
			get
			{
				return SCHEME_DELIMITER;
			}
		}

		public string[] Segments
		{
			get
			{
				return _request.RequestUri.Segments;
			}
		}

		public string Url
		{
			get
			{
				return _request.RequestUri.OriginalString;
			}
		}
	}
}
