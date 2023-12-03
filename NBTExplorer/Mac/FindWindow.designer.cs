// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;

namespace NBTExplorer.Mac
{
	[Register ("FindWindowController")]
	partial class FindWindowController
	{
		[Outlet]
		AppKit.NSButton _nameToggle { get; set; }

		[Outlet]
		AppKit.NSButton _valueToggle { get; set; }

		[Outlet]
		AppKit.NSTextField _nameField { get; set; }

		[Outlet]
		AppKit.NSTextField _valueField { get; set; }

		[Action ("ActionFind:")]
		partial void ActionFind (Foundation.NSObject sender);

		[Action ("ActionCancel:")]
		partial void ActionCancel (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (_nameToggle != null) {
				_nameToggle.Dispose ();
				_nameToggle = null;
			}

			if (_valueToggle != null) {
				_valueToggle.Dispose ();
				_valueToggle = null;
			}

			if (_nameField != null) {
				_nameField.Dispose ();
				_nameField = null;
			}

			if (_valueField != null) {
				_valueField.Dispose ();
				_valueField = null;
			}
		}
	}

	[Register ("FindWindow")]
	partial class FindWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
