using System.Collections.Generic;

namespace PlayerDataBackupTool_CSharp
{
	class PlayerInvDataPojo
	{
		//public string Id { get; set; }
		public string player_name { get; set; }
		public string player_uuid { get; set; }
		public Dictionary<string, string> data { get; set; } = new Dictionary<string, string>();
	}
	/*
	{
		"_id": {
			"$oid": "6263d6a6e97d3fc772f53a5a"
		},
		"player_name": "qwq",
		"player_uuid": "uuid",
		"data": {
			"20020423": "Base64-xxxxxxxx",
			"20020424": "Base64-xxxxxxxx",
			"20020425": "Base64-xxxxxxxx"
		}
	}
	*/
}