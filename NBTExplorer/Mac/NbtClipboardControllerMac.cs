using System;
using AppKit;
using Foundation;
using ObjCRuntime;
using Substrate.Nbt;
using System.Runtime.InteropServices;
using NBTModel.Interop;

namespace NBTExplorer.Mac
{
	public class NbtClipboardControllerMac : INbtClipboardController
	{
		public void CopyToClipboard (NbtClipboardData data)
		{
            NbtClipboardDataMac dataItem = new NbtClipboardDataMac(data);

			NSPasteboard pasteboard = NSPasteboard.GeneralPasteboard;
			pasteboard.ClearContents();
			pasteboard.WriteObjects(new NSPasteboardWriting[] { dataItem });
		}

		public NbtClipboardData CopyFromClipboard ()
		{
			NSPasteboard pasteboard = NSPasteboard.GeneralPasteboard;
			Class[] classArray = { new Class("NbtClipboardDataMac") };
            NSObject[] items = pasteboard.ReadObjectsForClasses (classArray, new NSDictionary());

			foreach (NbtClipboardDataMac item in items) {
				if (item == null)
					continue;

				TagNode node = item.Node;
				if (node == null)
					continue;

				return new NbtClipboardData(item.Name, node);
			}

			return null;
		}

		public bool ContainsData
		{
			get {  
				NSPasteboard pasteboard = NSPasteboard.GeneralPasteboard;
                Class[] classArray = { new Class("NbtClipboardDataMac") };
                NSObject[] items = pasteboard.ReadObjectsForClasses (classArray, new NSDictionary());
				return items != null && items.Length > 0;
			}
		}
	}

	[Adopts("NSCoding")]
	[Adopts("NSPasteboardReading")]
    [Adopts("NSPasteboardWriting")]
    [Register("NbtClipboardDataMac")]
	public class NbtClipboardDataMac : NSPasteboardWriting
    {
		static AdoptsAttribute _readingProtocol = new AdoptsAttribute ("NSPasteboardReading");
        static AdoptsAttribute _writingProtocol = new AdoptsAttribute("NSPasteboardWriting");
        static AdoptsAttribute _codingProtocol = new AdoptsAttribute("NSCoding");

		private static string _pasteboardItemName = "jaquadro.nbtexplorer.nbtClipboardDataMac";

		public static NbtClipboardDataMac Type
		{
			get {
                NbtClipboardDataMac inst = new NbtClipboardDataMac();
				return inst;
			}
		}

		private string _name;
		private byte[] _data;

		private bool _bypassProtocolCheck = true;

		private NbtClipboardDataMac()
		{
			_name = "";
			_data = new byte[0];
		}

        public NbtClipboardDataMac(NbtClipboardData data)
        {
            Name = data.Name;
            Node = data.Node;
        }

        public override bool ConformsToProtocol (IntPtr protocol)
		{
			// XXX: This is a hack!  There seems to be a bug in Xamarin.Mac resulting in different handle addresses
			// for two protocols of (seemingly) the same name, so we have no way to make objc accept that we
			// implement a given protocol.  objc runtime method protocol_getName should be able to help us, but it
			// crashes the runtime.
			if (_bypassProtocolCheck)
				return true;

            if (protocol == _writingProtocol.ProtocolHandle)
                return true;
            if (protocol == _readingProtocol.ProtocolHandle)
				return true;
			if (protocol == _codingProtocol.ProtocolHandle)
				return true;
			return base.ConformsToProtocol (protocol);
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public TagNode Node
		{
			get { return NbtClipboardData.DeserializeNode(_data); }
			set { _data = NbtClipboardData.SerializeNode(value); }
		}

		[Export ("initWithCoder:")]
		public static NbtClipboardDataMac InitWithCoder(NSCoder coder)
		{
            NbtClipboardDataMac data = new NbtClipboardDataMac();
			data._name = (NSString)coder.DecodeObject("name");
            data._data = coder.DecodeBytes("data");
			return data;
		}

		[Export ("encodeWithCoder:")]
		public void Encode (NSCoder coder)
		{
			coder.Encode ((NSString)_name, "name");
			coder.Encode (_data, "data");
		}

        [Export("readableTypesForPasteboard:")]
        public static string[] GetReadableTypesForPasteboard (NSPasteboard pasteboard)
		{
			return new string[] { _pasteboardItemName };
		}

        [Export("readingOptionsForType:pasteboard:")]
        public static NSPasteboardReadingOptions GetReadingOptionsForType (string type, NSPasteboard pasteboard)
		{
			if (type == _pasteboardItemName)
				return NSPasteboardReadingOptions.AsKeyedArchive;
			else
				return 0;
		}

		public NSObject InitWithPasteboardPropertyList (NSObject propertyList, string type)
		{
			if (type == _pasteboardItemName) {
				return null;
			}
			else
				return null;
		}

        [Export("writableTypesForPasteboard:")]
        public override string[] GetWritableTypesForPasteboard(NSPasteboard pasteboard)
        {
            return new string[] { _pasteboardItemName };
        }

        [Export("pasteboardPropertyListForType:")]
        public override NSObject GetPasteboardPropertyListForType(string type)
        {
            if (type == _pasteboardItemName)
                return NSKeyedArchiver.ArchivedDataWithRootObject(this);
            else
                return null;
        }

        [Export("writingOptionsForType:pasteboard:")]
        public override NSPasteboardWritingOptions GetWritingOptionsForType(string type, NSPasteboard pasteboard)
        {
            return 0;
        }

        // XXX: This is a hack.  Not sure how to properly implement, but it's required either by pasteboard reading,
        // or is a side-effect of our protocol conformance hack.
        [Export("isSubclassOfClass:")]
		public bool IsSubclassOf (NSObject cl)
		{
			return false;
		}
	}
}

