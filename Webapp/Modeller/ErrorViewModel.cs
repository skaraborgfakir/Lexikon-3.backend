// Time-stamp: <2021-09-03 11:57:34 stefan>
//

using System;

namespace Webapp.Modeller
{
    public class ErrorViewModel
    {
	public string RequestId { get; set; }

	public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
