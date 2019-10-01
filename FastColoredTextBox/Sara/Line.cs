using System.Collections.Generic;
using System.Drawing;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace FastColoredTextBoxNS
{
    /// <summary>
    /// Range of characters to hide
    /// </summary>
    public struct HideRange
    {
        /// <summary>
        /// Start of the Range
        /// </summary>
        public int Start { get; set; }
        /// <summary>
        /// End of the Range
        /// </summary>
        public int End { get; set; }
    }

    public partial class Line
    {
        /// <summary>
        /// Used by consumer to store any form of data that is related to the line.
        /// </summary>
        public object LineData;
        /// <summary>
        /// Contains a list of Hidden text
        /// </summary>
        public List<HideRange> HiddenText { get; set; }
        /// <summary>
        /// Total number of hidden characters
        /// </summary>
        public int TotalHiddenCharacters
        {
            get
            {
                return HiddenText.Sum(hideRange => hideRange.End - hideRange.Start);
            }
        }
        /// <summary>
        /// Returns true when the character index is within a hidden range.
        /// </summary>
        public bool HideCharacter(int index)
        {
            return HiddenText.Any(hideRange => index > hideRange.Start - 1 && index < hideRange.End + 1);
        }
        /// <summary>
        /// True when the line has documentation.
        /// </summary>
        public bool IsDocumented;
        /// <summary>
        /// 
        /// </summary>
        public Color DocumentMapOverlayBackColor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Color PatternOverlayBackColor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Color PropertyBackColor { get; set; }

        internal void SaraLine(int uid)
        {
            HiddenText = new List<HideRange>();
        }
    }
}
