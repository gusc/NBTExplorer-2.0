using System;
using Foundation;
using AppKit;
using CoreGraphics;
using System.Drawing;
using ObjCRuntime;
using System.Collections.Generic;

namespace NBTExplorer.Mac
{
	[Register("ImageAndTextCell")]
	public class ImageAndTextCell : NSTextFieldCell
	{
		private NSImage _image;

		public ImageAndTextCell ()
		{
			Initialize();
		}

		public ImageAndTextCell (IntPtr handle)
			: base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public ImageAndTextCell (NSCoder coder) 
			: base (coder)
		{
			Initialize ();
		}

		private void Initialize ()
		{
			LineBreakMode = NSLineBreakMode.TruncatingTail;
			Selectable = true;

			PeriodicCleanup();
		}

		protected override void Dispose (bool disposing)
		{
			//if (_image != null)
			//	_image.Dispose();

			//if (_noDispose)
			//	Handle = IntPtr.Zero;

			base.Dispose (disposing);
		}

		static List<ImageAndTextCell> _refPool = new List<ImageAndTextCell>();

		// Method 1

		/*static IntPtr selRetain = Selector.GetHandle ("retain");

		[Export("copyWithZone:")]
		public virtual NSObject CopyWithZone(IntPtr zone) {
			ImageAndTextCell cell = new ImageAndTextCell() {
				Title = Title,
				Image = Image,
			};

			Messaging.void_objc_msgSend (cell.Handle, selRetain);

			return cell;
		}*/

		// Method 2

		/*[Export("copyWithZone:")]
		public virtual NSObject CopyWithZone(IntPtr zone) {
			ImageAndTextCell cell = new ImageAndTextCell() {
				Title = Title,
				Image = Image,
			};

			_refPool.Add(cell);
			
			return cell;
		}

		[Export("dealloc")]
		public void Dealloc ()
		{
			_refPool.Remove(this);
			this.Dispose();
		}

		// Method 3

		static IntPtr selRetain = Selector.GetHandle ("retain");

		[Export("copyWithZone:")]
		public virtual NSObject CopyWithZone(IntPtr zone) {
			ImageAndTextCell cell = new ImageAndTextCell() {
				Title = Title,
				Image = Image,
			};

			_refPool.Add(cell);
			Messaging.void_objc_msgSend (cell.Handle, selRetain);
			
			return cell;
		}

		// Method 4

		static IntPtr selRetain = Selector.GetHandle ("retain");
		static IntPtr selRetainCount = Selector.GetHandle("retainCount");

		[Export("copyWithZone:")]
		public virtual NSObject CopyWithZone (IntPtr zone)
		{
			ImageAndTextCell cell = new ImageAndTextCell () {
				Title = Title,
				Image = Image,
			};
			
			_refPool.Add (cell);
			Messaging.void_objc_msgSend (cell.Handle, selRetain);

			return cell;
		}*/

		static IntPtr selRetainCount = Selector.GetHandle("retainCount");

		public void PeriodicCleanup ()
		{
			List<ImageAndTextCell> markedForDelete = new List<ImageAndTextCell> ();

			//foreach (ImageAndTextCell cell in _refPool) {
			//	uint count = Messaging.UInt32_objc_msgSend (cell.Handle, selRetainCount);
			//	if (count == 1)
			//		markedForDelete.Add (cell);
			//}

			//foreach (ImageAndTextCell cell in markedForDelete) {
			//	_refPool.Remove (cell);
			//	cell.Dispose ();
			//}
		}

		// Method 5

		static IntPtr selCopyWithZone = Selector.GetHandle("copyWithZone:");

		//[Export("copyWithZone:")]
		//public virtual NSObject CopyWithZone(IntPtr zone) {
		//	IntPtr copyHandle = Messaging.IntPtr_objc_msgSendSuper_IntPtr(SuperHandle, selCopyWithZone, zone);
		//	ImageAndTextCell cell = new ImageAndTextCell(copyHandle) {
		//		Image = Image,
		//	};

		//	_refPool.Add(cell);
			
		//	return cell;
		//}

		/*[Export("dealloc")]
		public void Dealloc ()
		{
			//_refPool.Remove(this);
			//Messaging.void_objc_msgSendSuper(SuperHandle, selDealloc);
		}*/




		/*[Export("copyWithZone:")]
		public virtual NSObject CopyWithZone(IntPtr zone) {
			ImageAndTextCell cell = new ImageAndTextCell() {
				Title = Title,
				Image = Image,
			};
			cell._noDispose = true;
			return cell;
		}*/

		//static List<ImageAndTextCell> _refPool = new List<ImageAndTextCell>();

		//static IntPtr selRetain = Selector.GetHandle ("retain");
		//static IntPtr selAutoRelease = Selector.GetHandle("autorelease");
		//static IntPtr selRelease = Selector.GetHandle("release");
		//static IntPtr selCopyWithZone = Selector.GetHandle("copyWithZone:");

		/*[Export("copyWithZone:")]
		public NSObject CopyWithZone (IntPtr zone)
		{
			//IntPtr copy = Messaging.IntPtr_objc_msgSendSuper_IntPtr(SuperHandle, selCopyWithZone, zone);
			//var cloned = new ImageAndTextCell(copy);
			//cloned.Title = Title;
			//cloned.Image = Image;

			var cloned = new ImageAndTextCell { 
				Title = Title,
				Image = Image,
			};
			cloned._copyCalled = true;

			_refPool.Add(cloned);

			//Messaging.void_objc_msgSend (cloned.Handle, selRetain);
			return cloned;
		}

		//static IntPtr selDealloc = Selector.GetHandle("dealloc");

		[Export("dealloc")]
		public void Dealloc ()
		{
			_deallocCalled = true;
			_refPool.Remove(this);

			//Messaging.void_objc_msgSendSuper(SuperHandle, selDealloc);
		}*/

		public new NSImage Image
		{
			get { return _image; }
			set { _image = value; }
		}

        public override CGRect ImageRectForBounds(CGRect theRect)
        {
			if (_image != null) {
				CGPoint origin = new CGPoint(theRect.X + 3, theRect.Y + (float)Math.Ceiling((theRect.Height - _image.Size.Height) / 2));
				return new CGRect(origin, _image.Size);
			}
			else
				return CGRect.Empty;
		}

		public override CGRect TitleRectForBounds (CGRect theRect)
		{
			if (_image != null) {
                CGPoint origin = new CGPoint(theRect.X + 3 + _image.Size.Width, theRect.Y);
                CGSize size = new CGSize(theRect.Width - 3 - _image.Size.Width, theRect.Height);
				return new CGRect(origin, size);
			}
			else
				return base.TitleRectForBounds(theRect);
		}

		public override void EditWithFrame (CGRect aRect, NSView inView, NSText editor, NSObject delegateObject, NSEvent theEvent)
		{
            CGRect textFrame, imageFrame;
			aRect.Divide(3 + _image.Size.Width, CGRectEdge.MinXEdge, out imageFrame, out textFrame);
			base.EditWithFrame(textFrame, inView, editor, delegateObject, theEvent);
		}

		public override void SelectWithFrame(CGRect aRect, NSView inView, NSText editor, NSObject delegateObject, nint selStart, nint selLength)
        {
            CGRect textFrame, imageFrame;
			aRect.Divide(3 + _image.Size.Width, CGRectEdge.MinXEdge, out imageFrame, out textFrame);
			base.SelectWithFrame(textFrame, inView, editor, delegateObject, selStart, selLength);
		}

		public override void DrawWithFrame (CGRect cellFrame, NSView inView)
		{
			//Assert (!_deallocCalled, "DrawWithFrame: Dealloc was called on object");
			//Assert (!_disposeCalled, "DrawWithFrame: Dispose was called on object");

			if (_image != null) {
                CGRect imageFrame;
				cellFrame.Divide (3 + _image.Size.Width, CGRectEdge.MinXEdge, out imageFrame, out cellFrame);

				if (DrawsBackground) {
					BackgroundColor.Set ();
					NSGraphics.RectFill (imageFrame);
				}

				imageFrame.X += 3;
				imageFrame.Size = _image.Size;

				//if (inView.IsFlipped) {
				//	imageFrame.Y += (float)Math.Ceiling((cellFrame.Height + imageFrame.Height) / 2);
				//}
				//else {
				imageFrame.Y += (float)Math.Ceiling ((cellFrame.Height - imageFrame.Height) / 2);
				//}

				_image.Draw (imageFrame, new CGRect(CGPoint.Empty, _image.Size), NSCompositingOperation.SourceOver, 1f, true, null);
			}

			base.DrawWithFrame (cellFrame, inView);
		}

		public override CGSize CellSize
		{
			get {
				if (_image != null)
					return new CGSize(base.CellSize.Width + 3 + _image.Size.Width, base.CellSize.Height);
				else
					return new CGSize(base.CellSize.Width + 3, base.CellSize.Height);
			}
		}

		public override NSCellHit HitTest (NSEvent forEvent, CGRect inRect, NSView ofView)
		{
			CGPoint point = ofView.ConvertPointFromView (forEvent.LocationInWindow, null);

			if (_image != null) {
                CGRect imageFrame;
				inRect.Divide(3 + _image.Size.Width, CGRectEdge.MinXEdge, out imageFrame, out inRect);

				imageFrame.X += 3;
				imageFrame.Size = _image.Size;
				if (ofView.IsMouseInRect(point, imageFrame))
					return NSCellHit.ContentArea;
			}

			return base.HitTest (forEvent, inRect, ofView);
		}

		private void Assert (bool condition, string message)
		{
			if (!condition)
				throw new Exception("Assert failed: " + message);
		}
	}
}

