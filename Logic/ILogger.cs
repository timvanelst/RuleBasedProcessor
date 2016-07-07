using System;

namespace Logic
{
    public interface ILogger
    {
        void Error(Exception exception);
    }
}