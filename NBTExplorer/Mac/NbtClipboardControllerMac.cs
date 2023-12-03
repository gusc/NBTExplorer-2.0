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
			NbtClipboardDataMacWriter dataItem = new NbtClipboardDataMacWriter(data);

			NSPasteboard pasteboard = NSPasteboard.GeneralPasteboard;
			pasteboard.ClearContents();
			pasteboard.WriteObjects(new NSPasteboardWriting[] { dataItem });
		}

		public NbtClipboardData CopyFromClipboard ()
		{
			NSPasteboard pasteboard = NSPasteboard.GeneralPasteboard;
            Class[] classArray = { new Class("NbtClipboardDataMacReader") };
            NSObject[] items = pasteboard.ReadObjectsForClasses (classArray, new NSDictionary());

			foreach (NbtClipboardDataMacReader item in items) {
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
                Class[] classArray = { new Class("NbtClipboardDataMacReader") };
                NSObject[] items = pasteboard.ReadObjectsForClasses (classArray, new NSDictionary());
				return items != null && items.Length > 0;
			}
		}
	}

	[Adopts("NSCoding")]
	[Adopts("NSPasteboardReading")]
	[Adopts("NSPasteboardWriting")]
	[Register("NbtClipboardDataMac")]
	public class NbtClipboardDataMacReader : NSPasteboardReading
	{
		static AdoptsAttribute _writingProtocol = new AdoptsAttribute ("NSPasteboardWriting");
		static AdoptsAttribute _readingProtocol = new AdoptsAttribute ("NSPasteboardReading");
		static AdoptsAttribute _codingProtocol = new AdoptsAttribute("NSCoding");

		private static string _pasteboardItemName = "jaquadro.nbtexplorer.nbtClipboardDataMac";

		public static NbtClipboardDataMacReader Type
		{
			get {
                NbtClipboardDataMacReader inst = new NbtClipboardDataMacReader();
				return inst;
			}
		}

		private string _name;
		private byte[] _data;

		private bool _bypassProtocolCheck = true;

		private NbtClipboardDataMacReader()
		{
			_name = "";
			_data = new byte[0];
		}

		public NbtClipboardDataMacReader(NbtClipboardData data)
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

			if (protocol == _readingProtocol.ProtocolHandle)
				return true;
			if (protocol == _writingProtocol.ProtocolHandle)
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
		public NbtClipboardDataMacReader(NSCoder coder)
			: base(NSObjectFlag.Empty)
		{
			_name = (NSString)coder.DecodeObject("name");
			_data = coder.DecodeBytes("data");
		}

		[Export ("encodeWithCoder:")]
		public void Encode (NSCoder coder)
		{
			coder.Encode ((NSString)_name, "name");
			coder.Encode (_data, "data");
		}

		public new string[] GetReadableTypesForPasteboard (NSPasteboard pasteboard)
		{
			return new string[] { _pasteboardItemName };
		}

		public new NSPasteboardReadingOptions GetReadingOptionsForType (string type, NSPasteboard pasteboard)
		{
			if (type == _pasteboardItemName)
				return NSPasteboardReadingOptions.AsKeyedArchive;
			else
				return 0;
		}

		[Obsolete]
		public override NSObject InitWithPasteboardPropertyList (NSObject propertyList, string type)
		{
			if (type == _pasteboardItemName) {
				return null;
			}
			else
				return null;
		}

		// XXX: This is a hack.  Not sure how to properly implement, but it's required either by pasteboard reading,
		// or is a side-effect of our protocol conformance hack.
		[Export("isSubclassOfClass:")]
		public bool IsSubclassOf (NSObject cl)
		{
			return false;
		}
	}

    [Adopts("NSCoding")]
    [Adopts("NSPasteboardReading")]
    [Adopts("NSPasteboardWriting")]
    [Register("NbtClipboardDataMac")]
    public class NbtClipboardDataMacWriter : NSPasteboardWriting
    {
        static AdoptsAttribute _writingProtocol = new AdoptsAttribute("NSPasteboardWriting");
        static AdoptsAttribute _readingProtocol = new AdoptsAttribute("NSPasteboardReading");
        static AdoptsAttribute _codingProtocol = new AdoptsAttribute("NSCoding");

        private static string _pasteboardItemName = "jaquadro.nbtexplorer.nbtClipboardDataMac";

        public static NbtClipboardDataMacWriter Type
        {
            get
            {
                NbtClipboardDataMacWriter inst = new NbtClipboardDataMacWriter();
                return inst;
            }
        }

        private string _name;
        private byte[] _data;

        private bool _bypassProtocolCheck = true;

        private NbtClipboardDataMacWriter()
        {
            _name = "";
            _data = new byte[0];
        }

        public NbtClipboardDataMacWriter(NbtClipboardData data)
        {
            Name = data.Name;
            Node = data.Node;
        }

        public override bool ConformsToProtocol(IntPtr protocol)
        {
            // XXX: This is a hack!  There seems to be a bug in Xamarin.Mac resulting in different handle addresses
            // for two protocols of (seemingly) the same name, so we have no way to make objc accept that we
            // implement a given protocol.  objc runtime method protocol_getName should be able to help us, but it
            // crashes the runtime.
            if (_bypassProtocolCheck)
                return true;

            if (protocol == _readingProtocol.ProtocolHandle)
                return true;
            if (protocol == _writingProtocol.ProtocolHandle)
                return true;
            if (protocol == _codingProtocol.ProtocolHandle)
                return true;
            return base.ConformsToProtocol(protocol);
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

        [Export("initWithCoder:")]
        public NbtClipboardDataMacWriter(NSCoder coder)
            : base(NSObjectFlag.Empty)
        {
            _name = (NSString)coder.DecodeObject("name");
            _data = coder.DecodeBytes("data");
        }

        [Export("encodeWithCoder:")]
        public void Encode(NSCoder coder)
        {
            coder.Encode((NSString)_name, "name");
            coder.Encode(_data, "data");
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
        public bool IsSubclassOf(NSObject cl)
        {
            return false;
        }
    }
}

