using ModernWpf.Controls;

using System;
using System.Windows.Markup;

namespace Fanda2.Common
{
    [MarkupExtensionReturnType(typeof(FontIcon))]
    public class FontIconExtension : MarkupExtension
    {
        public FontIconExtension()
        {
        }

        public FontIconExtension(string glyph)
        {
            Glyph = glyph;
        }

        [ConstructorArgument("glyph")]
        public string Glyph { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new FontIcon
            {
                Glyph = Glyph
            };
        }
    }
}
