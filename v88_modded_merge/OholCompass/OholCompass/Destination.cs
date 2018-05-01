using System;
using System.Drawing;
using System.Xml.Serialization;

namespace OholCompass
{
    [Serializable]
    public class Destination
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        [XmlElement(Type = typeof(XmlColor))]
        public Color Color { get; set; }

        public override string ToString()
        {
            return Name + " ( " + X + ", " + Y + " )";
        }
    }
}
