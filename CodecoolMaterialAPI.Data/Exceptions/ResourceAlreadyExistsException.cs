﻿namespace CodecoolMaterialsAPI.Data.Exceptions
{
    public class ResourceAlreadyExistsException : Exception
    {
        public ResourceAlreadyExistsException(string message) : base(message) { }
    }
}
