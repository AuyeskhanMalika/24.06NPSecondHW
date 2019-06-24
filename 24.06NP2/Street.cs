using System;

namespace _24._06NP2
{
    public class Street
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string PostIndex { get; set; }
        public string Name { get; set; }
    }
}