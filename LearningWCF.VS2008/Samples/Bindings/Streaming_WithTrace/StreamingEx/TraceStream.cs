// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.IO;
using System.Diagnostics;

namespace StreamingEx
{
	public class TraceStream: Stream
	{
		System.IO.Stream m_in = null;
		System.IO.Stream m_out = null;
			
		public override bool CanRead
		{
			get {
                Trace.WriteLine("TraceStream", String.Format("get_CanRead: {0}", m_in.CanRead));
				return m_in.CanRead;}
		}

		public override bool CanSeek
		{
			get {
                Trace.WriteLine("TraceStream", String.Format("get_CanSeek: {0}", m_in.CanSeek));
				return m_in.CanSeek;}
		}

		public override bool CanWrite
		{
			get {
                Trace.WriteLine("TraceStream", String.Format("get_CanWrite: {0}", m_in.CanWrite));
				return m_in.CanWrite;}
		}

		public override long Length
		{
			get {
                Trace.WriteLine("TraceStream", String.Format("get_Length: {0}", m_in.Length));
				return m_in.Length;}
		}

		public override void SetLength(
			long val
			)
		{
                Trace.WriteLine("TraceStream", String.Format("SetLength({0})", val));
            m_in.SetLength(val);
		}

		public override long Position
		{
			get {
                Trace.WriteLine("TraceStream", String.Format("get_Position: {0}", m_in.Position));
				return m_in.Position;}
			set {
                Trace.WriteLine("TraceStream", String.Format("set_Position: {0}", m_in.Position));
				m_in.Position = value;}
		}
		
		public TraceStream(System.IO.Stream stream)
		{
			Trace.WriteLine("TraceStream", String.Format("TraceStream created."));
			m_in = stream;	
		}

		public override IAsyncResult BeginRead(
			byte[] buffer,
			int offset,
			int count,
			AsyncCallback callback,
			object state
			)
		{
			Trace.WriteLine("TraceStream", String.Format("BeginRead(): offset({0}), count({1})", offset, count));
            return m_in.BeginRead(buffer, offset, count, callback, state);
		}

		public override IAsyncResult BeginWrite(
			byte[] buffer,
			int offset,
			int count,
			AsyncCallback callback,
			object state
			)
		{
			Trace.WriteLine("TraceStream", String.Format("BeginWrite(): offset({0}), count({1})", offset, count));
            return m_in.BeginWrite(buffer, offset, count, callback, state);
		}

		public override void Close()
		{
			Trace.WriteLine("TraceStream", String.Format("Close()"));
			m_in.Close();
		}

		public override int EndRead(
			IAsyncResult asyncResult
			)
		{
			Trace.WriteLine("TraceStream", "EndRead()");
			return m_in.EndRead(asyncResult);
		}

		public override void EndWrite(
			IAsyncResult asyncResult
			)
		{
			Trace.WriteLine("TraceStream", "EndWrite()");
			m_in.EndWrite(asyncResult);
		}


		public override void Flush()
		{
			Trace.WriteLine("TraceStream", "Flush()");
			m_in.Flush();
		}


		public override long Seek(
			long offset,
			SeekOrigin origin
			)
		{
			Trace.WriteLine("TraceStream", String.Format("Seek(): offset({0}), origin({1})", offset, origin));
			return m_in.Seek(offset, origin);
		}


		public override int Read(byte[] buffer,
				   int offset, int count)
		{
			Trace.WriteLine("TraceStream", String.Format("Read(): offset({0}), count({1})", offset, count));
			return m_in.Read(buffer, offset, count);
		}

		public override void Write(
			byte[] buffer,
			int offset,
			int count
			)
		{
			Trace.WriteLine("TraceStream", String.Format("Write(): offset({0}), count({1})", offset, count));
			m_in.Write(buffer, offset, count);

		}

	}
}
