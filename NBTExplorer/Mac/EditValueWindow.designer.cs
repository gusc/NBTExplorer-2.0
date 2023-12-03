// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;

namespace NBTExplorer.Mac
{
	[Register ("EditValueWindowController")]
	partial class EditValueWindowController
	{
		[Outlet]
		AppKit.NSTextField _valueField { get; set; }

		[Action ("ActionOK:")]
		partial void ActionOK (Foundation.NSObject sender);

		[Action ("ActionCancel:")]
		partial void ActionCancel (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (_valueField != null) {
				_valueField.Dispose ();
				_valueField = null;
			}
		}
	}

	[Register ("EditValueWindow")]
	partial class EditValueWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
