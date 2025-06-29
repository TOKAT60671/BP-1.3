using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class GObjectDto
    {
        public Guid Id { get; set; }
        public int TypeIndex { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public Guid SaveGameId { get; set; }
    }
}
