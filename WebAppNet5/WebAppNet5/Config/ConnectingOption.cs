using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5
{
    /// <summary>
    /// 配置文件选项设置
    /// </summary>
    public class Rootobject
    {
        public Logging Logging { get; set; }
        public Connectingstrings ConnectingStrings { get; set; }
        public string AllowedHosts { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }
        public string MicrosoftHostingLifetime { get; set; }
    }

    public class Connectingstrings
    {
        public string WriteConnecting { get; set; }
        public string[] ReadConnecting { get; set; }
        public Testconnecting TestConnecting { get; set; }
    }

    public class Testconnecting
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string MicrosoftHostingLifetime { get; set; }
    }


}
