// Time-stamp: <2021-08-19 12:12:51 stefan>

using System;

namespace webapp.Models
{
    public class ErrorViewModel
    {
	public string RequestId { get; set; }

	public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
