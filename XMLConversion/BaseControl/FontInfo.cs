using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace XMLConversion.BaseControl
{
    public class FontInfo
    {
        public FontFamily Family { get; set; }
        public double Size { get; set; }
        public FontStyle Style { get; set; }
        public FontWeight Weight { get; set; }
        public FontStretch Stretch { get; set; }
        public SolidColorBrush BrushColor { get; set; }


        public FontInfo()
        { }
        public FontInfo(FontFamily fontFamily, double fontSize, FontStyle fontStyle, FontStretch fontStretch, FontWeight fontWeight, SolidColorBrush brush)
        {
            this.Family= fontFamily;
            this.Size = fontSize;
            this.Style= fontStyle;
            this.Stretch= fontStretch;
            this.Weight= fontWeight;
            this.BrushColor= brush;
        }


        #region Utils
        public static string TypefaceToString(FamilyTypeface ttf)
        {
            StringBuilder sb = new StringBuilder(ttf.Stretch.ToString());
            sb.Append("-");
            sb.Append(ttf.Weight.ToString());
            sb.Append("-");
            sb.Append(ttf.Style.ToString());
            return sb.ToString();
        }

        public static void ApplyFont(Control control, FontInfo font)
        {
            control.FontFamily = font.Family;
            control.FontSize = font.Size;
            control.FontStyle = font.Style;
            control.FontStretch = font.Stretch;
            control.FontWeight = font.Weight;
            control.Foreground = font.BrushColor;
        }

        public static FontInfo GetControlFont(Control control)
        {
            FontInfo font = new FontInfo();
            font.Family = control.FontFamily;
            font.Size = control.FontSize;
            font.Style = control.FontStyle;
            font.Stretch = control.FontStretch;
            font.Weight = control.FontWeight;
            font.BrushColor = (SolidColorBrush)control.Foreground;
            return font;
        }
        #endregion

        public FontColor Color
        {
            get
            {
                return AvailableColors.GetFontColor(this.BrushColor);
            }
        }

        public FamilyTypeface TypeFace
        {
            get
            {
                FamilyTypeface ttf = new FamilyTypeface();
                ttf.Stretch = this.Stretch;
                ttf.Weight = this.Weight;
                ttf.Style = this.Style;
                return ttf;
            }
        }
    }
}
