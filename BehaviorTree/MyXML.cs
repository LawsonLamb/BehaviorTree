using System;
using System.Collections.Generic;
using System.IO;
namespace BehaviorTree
{



	public class MyXML
	{

		const char startTag = '<';
		const char endTag = '>';
		const char closeTag = '/';
		string _fileName;

		public MyXML (string FileName)
		{
			_fileName = FileName;
		}	


		public void Read(){

			StreamReader reader = new StreamReader (_fileName);
			List<string> data = new List<string> ();
			while (!reader.EndOfStream) {


			
				string line = reader.ReadLine ();

				line = line.TrimStart (' ');
				line = line.TrimStart(startTag);
				line = line.TrimEnd (endTag);
				 data.Add(line);	

				Console.WriteLine (line);


			

			}

			reader.Close ();
					/*
			for (int i = 0; i < data.Count; i++) {
					//Console.WriteLine (data [i]);
				data[i] = data[i].TrimStart(' ');
				data [i] = data [i].TrimStart (startTag);
				data [i] = data [i].TrimEnd (endTag);
				data [i] = data [i].TrimEnd (closeTag);
				Console.WriteLine (data [i]);


			}
			*/

		}









	}
}

