using System.Collections.Generic;
using Crawler.ZVG.Informer;
using Crawler.ZVG.ZVG.Entity;

namespace Crawler.ZVG.ZVG.Converter
{
    public interface IZvgObjectConverter
    {
        IEnumerable<Property> ToProperties(ZvgRows zvgRows);
    }
}