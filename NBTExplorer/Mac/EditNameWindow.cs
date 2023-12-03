
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace NBTExplorer.Mac
{
	public partial class EditNameWindow : AppKit.NSWindow
	{
		#region Constructors
		
		// Called when created from unmanaged code
		public EditNameWindow (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public EditNameWindow (NSCoder coder) : base (coder)
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

