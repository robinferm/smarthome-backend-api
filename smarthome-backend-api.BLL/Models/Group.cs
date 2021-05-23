using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smarthome_backend_api.BLL.Models
{
    public class Group
    {
        public string name { get; set; }
        public string[] lights { get; set; }
        public object[] sensors { get; set; }
        public string type { get; set; }
        public State state { get; set; }
        public bool recycle { get; set; }
        public string _class { get; set; }
        public Action action { get; set; }
    }

    public class State
    {
        public bool all_on { get; set; }
        public bool any_on { get; set; }
    }

    public class Action
    {
        public bool on { get; set; }
        public int bri { get; set; }
        public int hue { get; set; }
        public int sat { get; set; }
        public string effect { get; set; }
        public float[] xy { get; set; }
        public int ct { get; set; }
        public string alert { get; set; }
        public string colormode { get; set; }
    }

}
