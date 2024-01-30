using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Feladat___04
{
	public class DateFormatConverter : JsonConverter<DateTime>
	{
        public DateFormatConverter()
        {
		}

		public override void Write(Utf8JsonWriter writer, DateTime date, JsonSerializerOptions options)
		{
			writer.WriteStringValue(date.ToString("yyy-MM-dd"));
		}
		public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string[] data = reader.GetString().Split(' ');
			int year = int.Parse(data[2]);
			int month = GetMonth(data[0]);
			int day = int.Parse(data[1]);

			return new DateTime(year, month, day);
		}

		private int GetMonth(string month)
        {
			Dictionary<string, int> months = new Dictionary<string, int>();
			months.Add("Jan", 1);
			months.Add("Feb", 2);
			months.Add("Mar", 3);
			months.Add("Apr", 4);
			months.Add("May", 5);
			months.Add("Jun", 6);
			months.Add("Jul", 7);
			months.Add("Aug", 8);
			months.Add("Sep", 9);
			months.Add("Oct", 10);
			months.Add("Nov", 11);
			months.Add("Dec", 12);

			return months[month];
				
        }
	}
}

