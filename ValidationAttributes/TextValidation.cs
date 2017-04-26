using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace EpamBlog.ValidationAttributes
{
    public class TextValidation : ValidationAttribute
    {
        private string[] m_forbiddenTags;

        public TextValidation( string[] _tags )
        {
            m_forbiddenTags = _tags;
        }

        public override bool IsValid( object value )
        {
            if ( value == null )
                return false;

            string text = value.ToString();
            foreach ( string tag in m_forbiddenTags )
            {
                if ( text.Contains( tag ) )
                {
                    return false;
                }
            }

            return true;
        }
    }
}