using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MicroServiceCoreLibrary.Converts
{
	#region SonarLint Disabled 放置區域
	// Disable the warning.
#pragma warning disable S125
	//S125	Remove this commented out code.	MicroServiceCoreLibrary
#pragma warning disable S3928
	//S3928	Use a constructor overloads that allows a more meaningful exception message to be provided.	MicroServiceCoreLibrary
#pragma warning disable CS8603
	//CS8603	可能有 Null 參考傳回。	MicroServiceCoreLibrary
#pragma warning disable CS8619
	//CS8619	型別 'ExpandoObject' 的值中參考型別可 Null 性與目標型別 'IDictionary<string, object>' 不符合。	MicroServiceCoreLibrary
#pragma warning disable CS8600
	//CS8600	正在將 Null 常值或可能的 Null 值轉換為不可為 Null 的型別。	MicroServiceCoreLibrary
#pragma warning disable IDE0059
	//IDE0059	對 'result' 指派了不必要的值	MicroServiceCoreLibrar
#pragma warning disable CA2208
	//CA2208	呼叫包含 message 及 (或) paramName 參數的 ArgumentOutOfRangeException 建構函式	MicroServiceCoreLibrary
	#endregion

	/// <summary>
	/// DynamicJsonConvert
	/// </summary>
	/// <seealso cref="System.Text.Json.Serialization.JsonConverter&lt;dynamic&gt;" />
	public class DynamicJsonConvert : JsonConverter<dynamic>
	{
		/// <summary>
		/// Reads and converts the JSON to type <typeparamref name="T" />.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="typeToConvert">The type to convert.</param>
		/// <param name="options">An object that specifies serialization options to use.</param>
		/// <returns>
		/// The converted value.
		/// </returns>
		public override dynamic Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.True)
			{
				return true;
			}

			if (reader.TokenType == JsonTokenType.False)
			{
				return false;
			}

			if (reader.TokenType == JsonTokenType.Number)
			{
				if (reader.TryGetInt64(out long l))
				{
					return l;
				}

				return reader.GetDouble();
			}

			if (reader.TokenType == JsonTokenType.String)
			{
				if (reader.TryGetDateTime(out DateTime datetime))
				{
					return datetime;
				}

				return reader.GetString();
			}

			if (reader.TokenType == JsonTokenType.StartObject)
			{
				using JsonDocument documentV = JsonDocument.ParseValue(ref reader);
				return ReadObject(documentV.RootElement);
			}

			if (reader.TokenType == JsonTokenType.StartArray)
			{
				using JsonDocument documentV = JsonDocument.ParseValue(ref reader);
				return ReadList(documentV.RootElement);
			}

			using JsonDocument document = JsonDocument.ParseValue(ref reader);
			return document.RootElement.Clone();
		}

		/// <summary>
		/// Reads the object.
		/// </summary>
		/// <param name="jsonElement">The json element.</param>
		/// <returns></returns>
		private object ReadObject(JsonElement jsonElement)
		{
			IDictionary<string, object> expandoObject = new ExpandoObject();
			foreach (var obj in jsonElement.EnumerateObject())
			{
				var k = obj.Name;
				var value = ReadValue(obj.Value);
				expandoObject[k] = value;
			}
			return expandoObject;
		}

		/// <summary>
		/// Reads the value.
		/// </summary>
		/// <param name="jsonElement">The json element.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentOutOfRangeException"></exception>
		private object ReadValue(JsonElement jsonElement)
		{
			object result = null;
			switch (jsonElement.ValueKind)
			{
				case JsonValueKind.Object:
					result = ReadObject(jsonElement);
					break;

				case JsonValueKind.Array:
					result = ReadList(jsonElement);
					break;

				case JsonValueKind.String:
					result = jsonElement.GetString();
					break;

				case JsonValueKind.Number:
					if (jsonElement.TryGetDecimal(out decimal d))
					{
						result = d;
					}
					else if (jsonElement.TryGetInt64(out long l))
					{
						result = l;
					}
					else
					{
						result = 0;
					}
					break;

				case JsonValueKind.True:
					result = true;
					break;

				case JsonValueKind.False:
					result = false;
					break;

				case JsonValueKind.Undefined:
				case JsonValueKind.Null:
					result = null;
					break;

				default:
					throw new ArgumentOutOfRangeException();
			}
			return result;
		}

		/// <summary>
		/// Reads the list.
		/// </summary>
		/// <param name="jsonElement">The json element.</param>
		/// <returns></returns>
		private object ReadList(JsonElement jsonElement)
		{
			IList<object> list = new List<object>();
			foreach (var item in jsonElement.EnumerateArray())
			{
				list.Add(ReadValue(item));
			}
			return list.Count == 0 ? null : list;
		}

		/// <summary>
		/// Writes a specified value as JSON.
		/// </summary>
		/// <param name="writer">The writer to write to.</param>
		/// <param name="value">The value to convert to JSON.</param>
		/// <param name="options">An object that specifies serialization options to use.</param>
		public override void Write(Utf8JsonWriter writer, dynamic value, JsonSerializerOptions options)
		{
			//LINQPad.Extensions.Dump(value, "Write Value");

			// https://docs.microsoft.com/en-us/dotnet/api/system.typecode
			switch (Type.GetTypeCode(value.GetType()))
			{
				case TypeCode.Boolean:
					writer.WriteBooleanValue(Convert.ToBoolean(value));
					break;

				case TypeCode.Int16:
				case TypeCode.Int32:
				case TypeCode.Int64:
				case TypeCode.UInt16:
				case TypeCode.UInt32:
				case TypeCode.UInt64:
					writer.WriteNumberValue(Convert.ToInt64(value));
					break;

				case TypeCode.Decimal:
					writer.WriteNumberValue(Convert.ToDecimal(value));
					break;

				case TypeCode.Char:
				case TypeCode.Empty:
				case TypeCode.String:
					writer.WriteStringValue(Convert.ToString(value));
					break;

				case TypeCode.DateTime:
					writer.WriteStringValue(Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss"));
					break;

				case TypeCode.DBNull:
					writer.WriteNullValue();
					break;

				default:
					writer.WriteRawValue(JsonSerializer.Serialize(value, new JsonSerializerOptions() { WriteIndented = true }));
					break;
			}
		}
	}
}

/*
 * void Main()
{
	var serializerOptions = new JsonSerializerOptions
	{
		Converters = { new DynamicJsonConverter() },
		WriteIndented = true
	};

	var jsonText = File.ReadAllText("sample.json");

	dynamic obj = JsonSerializer.Deserialize<dynamic>(jsonText, serializerOptions);

	LINQPad.Extensions.Dump(obj, "將 JSON 反序列化成 dynamic 物件");

	LINQPad.Extensions.Dump(obj.ppu);
	LINQPad.Extensions.Dump(obj.batters.batter[0].id);
	LINQPad.Extensions.Dump(obj.batters.batter[0].type);

	string json = JsonSerializer.Serialize(obj, serializerOptions);

	LINQPad.Extensions.Dump(json, "將 dynamic 物件序列化成 JSON 字串");
}
{
  "id": "0001",
  "type": "donut",
  "name": "Cake",
  "enabled": true,
  "ppu": 0.55,
  "birthday": "2022-06-11 21:42:55",
  "nothing": null,
  "batters": {
	"batter": [
	  { "id": "1001", "type": "Regular" },
	  { "id": "1002", "type": "Chocolate" },
	  { "id": "1003", "type": "Blueberry" },
	  { "id": "1004", "type": "Devil's Food" }
	]
  },
  "topping": [
	{ "id": "5001", "type": "None" },
	{ "id": "5002", "type": "Glazed" },
	{ "id": "5005", "type": "Sugar" },
	{ "id": "5007", "type": "Powdered Sugar" },
	{ "id": "5006", "type": "Chocolate with Sprinkles" },
	{ "id": "5003", "type": "Chocolate" },
	{ "id": "5004", "type": "Maple" }
  ]
}
 */