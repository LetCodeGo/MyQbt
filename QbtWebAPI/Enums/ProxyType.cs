namespace QbtWebAPI.Enums
{
	/// <summary>
	/// Proxy type.
	/// </summary>
    public enum ProxyType
    {
		/// <summary>
		/// Proxy is disabled.
		/// </summary>
		ProxyIsDisabled = -1,
		/// <summary>
		/// HTTP proxy without authentication.
		/// </summary>
		HttpProxyWithoutAuthentication = 1,
		/// <summary>
		/// SOCKS5 proxy without authentication
		/// </summary>
		Socks5ProxyWithoutAuthentication = 2,
		/// <summary>
		/// HTTP proxy with authentication
		/// </summary>
		HttpProxyWithAuthentication = 3,
		/// <summary>
		/// SOCKS5 proxy with authentication
		/// </summary>
		Socks5ProxyWithAuthentication = 4,
		/// <summary>
		/// SOCKS4 proxy without authentication
		/// </summary>
		Socks4ProxyWithoutAuthentication = 5
    };
}
