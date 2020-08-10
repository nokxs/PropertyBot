using System.Collections.Generic;
using Crawler.Interface;
using Crawler.Provider.ZVG.Entity;

namespace Crawler.Provider.ZVG.Converter
{
    internal interface IZvgObjectConverter
    {
        IEnumerable<Property> ToProperties(ZvgRows zvgRows);
    }
}