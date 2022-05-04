using System.Collections.Generic;

namespace BinaryGaps
{
    public class BinaryRepresentation
    {
        public bool HasBinaryGaps { get; set; }
        public int? NumberOfBinaryGaps { get; set; }
        public List<BinaryGap> BinaryGaps { get; set; }
    }
}
