﻿using System.Collections.Generic;
using Newtonsoft.Json;
using TicketsSearch.Models;
namespace TicketsSearch.Utilities
{
	public static class DeserialiseUtilities
	{
		public static List<Object> Deserialise<Object>(this string json)
		{
			return JsonConvert.DeserializeObject<List<Object>>(json);
		}
	}
}
