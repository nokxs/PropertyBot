using System.Collections.Generic;
using PropertyBot.Interface;
using PropertyBot.Provider.ZVG.Entity;

namespace PropertyBot.Provider.ZVG.Converter
{
    internal interface IZvgObjectConverter
    {
        IEnumerable<Property> ToProperties(ZvgRows zvgRows);
    }
}