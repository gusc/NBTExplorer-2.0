// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;

namespace NBTExplorer.Mac
{
	[Register ("EditStringWindowController")]
	partial class EditStringWindowController
	{
		[Outlet]
		AppKit.NSTextView _textView { get; set; }

		[Action ("ActionOK:")]
		partial void ActionOK (Foundation.NSObject sender);

		[Action ("ActionCancel:")]
		partial void ActionCancel (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (_textView != null) {
				_textView.Dispose ();
				_textView = null;
			}
		}
	}

	[Register ("EditStringWindow")]
	partial class EditStringWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
