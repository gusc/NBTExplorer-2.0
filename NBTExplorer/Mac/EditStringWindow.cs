
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace NBTExplorer.Mac
{
	public partial class EditStringWindow : AppKit.NSWindow
	{
		#region Constructors
		
		// Called when created from unmanaged code
		public EditStringWindow (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public EditStringWindow (NSCoder coder) : base (coder)
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

