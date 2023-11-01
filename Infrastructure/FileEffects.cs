using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class FileEffects
    {
        public int Id { get; set; }
        public int FileId { get; set; }
        public FileModel File { get; set; }
        public int EffectId { get; set; }
        public EffectModel Effect { get; set; }
    }
   
}
