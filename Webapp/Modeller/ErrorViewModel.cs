// Time-stamp: <2021-08-27 12:07:13 stefan>

using System;

namespace Webapp.Modeller
{
    public class ErrorViewModel
    {
	public string RequestId { get; set; }

	public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
