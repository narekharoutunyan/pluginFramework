using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class EffectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<FileEffects> FileEffects { get; set; }
    }
}
