// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;

namespace NBTExplorer
{
	[Register ("MainWindow")]
	partial class MainWindow
	{
		[Outlet]
		AppKit.NSToolbar _toolbar { get; set; }

		[Outlet]
		AppKit.NSToolbarItem _toolbarOpenFolder { get; set; }

		[Outlet]
		AppKit.NSToolbarItem _toolbarSave { get; set; }

		[Outlet]
		AppKit.NSToolbarItem _toolbarRename { get; set; }

		[Outlet]
		AppKit.NSToolbarItem _toolbarEdit { get; set; }

		[Outlet]
		AppKit.NSToolbarItem _toolbarDelete { get; set; }

		[Outlet]
		AppKit.NSToolbarItem _toolbarByte { get; set; }

		[Outlet]
		AppKit.NSToolbarItem _toolbarShort { get; set; }

		[Outlet]
		AppKit.NSToolbarItem _toolbarInt { get; set; }

		[Outlet]
		AppKit.NSToolbarItem _toolbarLong { get; set; }

		[Outlet]
		AppKit.NSToolbarItem _toolbarFloat { get; set; }

		[Outlet]
		AppKit.NSToolbarItem _toolbarDouble { get; set; }

		[Outlet]
		AppKit.NSToolbarItem _toolbarByteArray { get; set; }

		[Outlet]
		AppKit.NSToolbarItem _toolbarIntArray { get; set; }

		[Outlet]
		AppKit.NSToolbarItem _toolbarString { get; set; }

		[Outlet]
		AppKit.NSToolbarItem _toolbarList { get; set; }

		[Outlet]
		AppKit.NSToolbarItem _toolbarCompound { get; set; }

		[Outlet]
		AppKit.NSScrollView _mainScrollView { get; set; }

		[Outlet]
		AppKit.NSOutlineView _mainOutlineView { get; set; }

		[Action ("ActionOpenFolder:")]
		partial void ActionOpenFolder (Foundation.NSObject sender);

		[Action ("ActionSave:")]
		partial void ActionSave (Foundation.NSObject sender);

		[Action ("ActionRename:")]
		partial void ActionRename (Foundation.NSObject sender);

		[Action ("ActionEdit:")]
		partial void ActionEdit (Foundation.NSObject sender);

		[Action ("ActionDelete:")]
		partial void ActionDelete (Foundation.NSObject sender);

		[Action ("ActionInsertByte:")]
		partial void ActionInsertByte (Foundation.NSObject sender);

		[Action ("ActionInsertShort:")]
		partial void ActionInsertShort (Foundation.NSObject sender);

		[Action ("ActionInsertInt:")]
		partial void ActionInsertInt (Foundation.NSObject sender);

		[Action ("ActionInsertLong:")]
		partial void ActionInsertLong (Foundation.NSObject sender);

		[Action ("ActionInsertFloat:")]
		partial void ActionInsertFloat (Foundation.NSObject sender);

		[Action ("ActionInsertDouble:")]
		partial void ActionInsertDouble (Foundation.NSObject sender);

		[Action ("ActionInsertByteArray:")]
		partial void ActionInsertByteArray (Foundation.NSObject sender);

		[Action ("ActionInsertIntArray:")]
		partial void ActionInsertIntArray (Foundation.NSObject sender);

		[Action ("ActionInsertString:")]
		partial void ActionInsertString (Foundation.NSObject sender);

		[Action ("ActionInsertList:")]
		partial void ActionInsertList (Foundation.NSObject sender);

		[Action ("ActionInsertCompound:")]
		partial void ActionInsertCompound (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (_toolbar != null) {
				_toolbar.Dispose ();
				_toolbar = null;
			}

			if (_toolbarOpenFolder != null) {
				_toolbarOpenFolder.Dispose ();
				_toolbarOpenFolder = null;
			}

			if (_toolbarSave != null) {
				_toolbarSave.Dispose ();
				_toolbarSave = null;
			}

			if (_toolbarRename != null) {
				_toolbarRename.Dispose ();
				_toolbarRename = null;
			}

			if (_toolbarEdit != null) {
				_toolbarEdit.Dispose ();
				_toolbarEdit = null;
			}

			if (_toolbarDelete != null) {
				_toolbarDelete.Dispose ();
				_toolbarDelete = null;
			}

			if (_toolbarByte != null) {
				_toolbarByte.Dispose ();
				_toolbarByte = null;
			}

			if (_toolbarShort != null) {
				_toolbarShort.Dispose ();
				_toolbarShort = null;
			}

			if (_toolbarInt != null) {
				_toolbarInt.Dispose ();
				_toolbarInt = null;
			}

			if (_toolbarLong != null) {
				_toolbarLong.Dispose ();
				_toolbarLong = null;
			}

			if (_toolbarFloat != null) {
				_toolbarFloat.Dispose ();
				_toolbarFloat = null;
			}

			if (_toolbarDouble != null) {
				_toolbarDouble.Dispose ();
				_toolbarDouble = null;
			}

			if (_toolbarByteArray != null) {
				_toolbarByteArray.Dispose ();
				_toolbarByteArray = null;
			}

			if (_toolbarIntArray != null) {
				_toolbarIntArray.Dispose ();
				_toolbarIntArray = null;
			}

			if (_toolbarString != null) {
				_toolbarString.Dispose ();
				_toolbarString = null;
			}

			if (_toolbarList != null) {
				_toolbarList.Dispose ();
				_toolbarList = null;
			}

			if (_toolbarCompound != null) {
				_toolbarCompound.Dispose ();
				_toolbarCompound = null;
			}

			if (_mainScrollView != null) {
				_mainScrollView.Dispose ();
				_mainScrollView = null;
			}

			if (_mainOutlineView != null) {
				_mainOutlineView.Dispose ();
				_mainOutlineView = null;
			}
		}
	}

	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
