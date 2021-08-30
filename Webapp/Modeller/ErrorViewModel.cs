// Time-stamp: <2021-08-27 16:10:54 stefan>

using System;

namespace Webapp.Modeller
{
    public class ErrorViewModel
    {
	public string RequestId { get; set; }

	public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
