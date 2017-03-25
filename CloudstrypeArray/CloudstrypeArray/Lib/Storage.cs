﻿using System;
using System.IO;
using log4net;

namespace CloudstrypeArray.Lib.Storage
{
	public class StorageFullException : Exception
	{
		public StorageFullException(string msg) : base(msg) { }
	}

	public class Storage
	{
		private static readonly ILog Logger = LogManager.GetLogger(typeof(Storage));

		// Implements a key/value store that is backed by a data directory
		// containing files.
		//
		// .cloudstrype/<id of chunk>

		public string Root;
		public long Size = -1;
		public long UsedSize = 0;

		public Storage(string path, long size)
		{
			if (!path.EndsWith(".cloudstrype") && !path.EndsWith(".cloudstrype/"))
			{
				path = Path.Combine(path, ".cloudstrype");
			}
			Size = size;
			Open (path);
		}

		public Storage(string path) : this(path, -1) { }

		public Storage(long totalSize) : this(Path.GetTempPath(), totalSize) { }

		public Storage() : this(Path.GetTempPath(), -1) { }

		protected void Open(string path)
		{
			try
			{
			if ((File.GetAttributes (path) & FileAttributes.Directory) != FileAttributes.Directory)
				throw new IOException ("Cannot use file as storage location");
			}
			catch (FileNotFoundException) {
				Directory.CreateDirectory (path);
			}
			Root = path;
			UsedSize = GetUsedSize ();
		}

		protected long GetUsedSize()
		{
			long size = 0;
			string[] files = List ();
			for (int i = 0; i < files.Length; i++) {
				size += new FileInfo (Path.Combine (Root, files[i])).Length;
			}
			Logger.DebugFormat ("Using {0} bytes in {1}", size, Root);
			return size;
		}

		public void Write(string id, byte[] data)
		{
			if (Size != -1 && UsedSize + data.Length > Size)
				throw new StorageFullException ("Storage allocation consumed");
			string fullPath = Path.Combine (Root, id);
			Logger.DebugFormat ("Writing {0} bytes to {1}", data.Length, fullPath);
			// Open FileStream directly so we can prevent overwriting existing file.
			using (FileStream file = 
				new FileStream(fullPath, FileMode.CreateNew, FileAccess.Write, FileShare.None))
			{
				file.Write (data, 0, data.Length);
			}
			UsedSize += data.Length;
		}

		public byte[] Read(string id)
		{
			string fullPath = Path.Combine (Root, id);
			Logger.DebugFormat ("Reading from {0}", fullPath);
			using (FileStream file = File.OpenRead (fullPath)) {
				byte[] data = new byte[file.Length];
				file.Read (data, 0, data.Length);
				return data;
			}
		}

		public void Delete(string id)
		{
			string fullPath = Path.Combine (Root, id);
			Logger.DebugFormat ("Deleting {0}", fullPath);
			long size = new FileInfo (fullPath).Length;
			File.Delete (fullPath);
			UsedSize -= size;
		}

		public string[] List()
		{
			return Directory.GetFiles (Root);
		}
	}
}
