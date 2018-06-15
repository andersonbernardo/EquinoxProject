using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Equinox.Infra.CrossCutting.Tools
{
    public class Json
    {
        public static string Serialize(object model)
        {
            return Regex.Unescape(Newtonsoft.Json.JsonConvert.SerializeObject(model, new Newtonsoft.Json.JsonSerializerSettings(){ StringEscapeHandling = Newtonsoft.Json.StringEscapeHandling.EscapeHtml}));
        }
    }
}
