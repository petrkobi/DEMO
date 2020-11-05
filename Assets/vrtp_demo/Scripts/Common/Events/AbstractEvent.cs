﻿namespace _Quiz.Scripts.Common.Events
{
    public class AbstractEvent
    {
        public virtual string LogInfo()
        {
            return "";
        }

        public virtual bool LogToConsole()
        {
            throw new System.NotImplementedException();
        }
    }
}