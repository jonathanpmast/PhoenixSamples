﻿namespace PhoenixSample.PCL.TexturePacker
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using PhoenixSample.PCL;
    using PhoenixSystem.Monogame;
    using PhoenixSystem.Monogame.Render.Sprite;
    public class SpriteSheetLoader
	{
		private readonly ContentManager contentManager;
		private readonly IFileReader fileReader;
		public SpriteSheetLoader(ContentManager contentManager, IFileReader fileReader)
		{
			this.contentManager = contentManager;
			this.fileReader = fileReader;
		}

		public SpriteSheet MultiLoad(string imageResourceFormat, int numSheets)
		{
			SpriteSheet result = new SpriteSheet();
			for (int i = 0; i < numSheets; i++)
			{
				string imageResource = string.Format(imageResourceFormat, i);

				SpriteSheet tmp = Load(imageResource);
				result.Add(tmp);
			}
			return result;
		}


		public SpriteSheet Load(string imageResource)
		{
			var texture = this.contentManager.Load<Texture2D>(imageResource);

			var dataFile = Path.Combine(
				this.contentManager.RootDirectory,
				Path.ChangeExtension(imageResource, "txt"));

			var dataFileLines = fileReader.GetFileContents(dataFile);

			var sheet = new SpriteSheet();

			foreach (
				var cols in
					from row in dataFileLines
					where !string.IsNullOrEmpty(row) && !row.StartsWith("#")
					select row.Split(';'))
			{
				if (cols.Length != 10)
				{
					throw new InvalidDataException("Incorrect format data in spritesheet data file");
				}

				var isRotated = int.Parse (cols [1]) == 1;
				var name = cols[0];
				var sourceRectangle = new Rectangle(
					int.Parse(cols[2]),
					int.Parse(cols[3]),
					int.Parse(cols[4]),
					int.Parse(cols[5]));
				var size = new Vector2(
					int.Parse(cols[6]),
					int.Parse(cols[7]));
				var pivotPoint = new Vector2(
					float.Parse(cols[8]),
					float.Parse(cols[9]));
				var sprite = new SpriteFrame(texture, sourceRectangle, size, pivotPoint, isRotated);

				sheet.SpriteList.Add(name, sprite);
			}

			return sheet;
		}
		

	}
}