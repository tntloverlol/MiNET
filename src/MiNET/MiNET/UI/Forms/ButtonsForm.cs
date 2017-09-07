﻿using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using MiNET.UI.Elements;

namespace MiNET.UI.Forms
{
	public class ButtonsForm : IForm
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public List<Button> Buttons { get; set; }

		public ButtonsForm(string title, string content = "")
		{
			Title = title;
			Content = content;
			Buttons = new List<Button>();
		}

		public string GetData()
		{
			var buttons = GetButtons();
			var j = new JObject
			{
				{ "type", "form" },
				{ "title", Title },
				{ "content", Content }
			};
			if(buttons.Count > 0)
			{
				j.Add("button1", buttons[0]);
			}
			if(buttons.Count > 1)
			{
				j.Add("button2", buttons[1]);
			}
			return j.ToString(Newtonsoft.Json.Formatting.None);
		}

		public JArray GetButtons()
		{
			var j = new JArray();
			foreach(var button in Buttons)
			{
				j.Add(button);
			}
			return j;
		}

		public void Process(Player player, JArray response)
		{
			for (var i = 0; i < response.Count; i++)
			{
				Buttons[i].Process(player, response[i]);
			}
		}
	}
}
