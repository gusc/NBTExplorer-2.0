
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace NBTExplorer.Mac
{
	public partial class CreateNodeWindow : AppKit.NSWindow
	{
		#region Constructors
		
		// Called when created from unmanaged code
		public CreateNodeWindow (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public CreateNodeWindow (NSCoder coder) : base (coder)
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

