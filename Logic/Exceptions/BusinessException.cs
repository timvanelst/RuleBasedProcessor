using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class BusinessException : Exception
    {
        private readonly List<string> translatedMessages;

        public BusinessException(params string[] translatedMessage)
        {
            this.translatedMessages = translatedMessage.ToList();
        }

        public IList<string> TranslatedMessages
        {
            get
            {
                return translatedMessages;
            }
        }
    }
}