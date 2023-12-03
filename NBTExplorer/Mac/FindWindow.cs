
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace NBTExplorer.Mac
{
	public partial class FindWindow : AppKit.NSWindow
	{
		#region Constructors
		
		// Called when created from unmanaged code
		public FindWindow (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public FindWindow (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
		}
		
		#endregion
	}
}

